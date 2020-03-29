using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    ISpawningBehavior enemySpawnerMode;
    public Transform spawnMode, target;

    private void Start()
    {
        SetNoSpawnMode();
        Invoke("SetDefaultSpawnMode", 1);
    }

    public void SetDefaultSpawnMode()
    {
        enemySpawnerMode = spawnMode.GetComponent<DefaultEnemySpawn>();
    }

    public void SetNoSpawnMode()
    {
        enemySpawnerMode = spawnMode.GetComponent<NoEnemySpawning>();
    }

    private void Update()
    {
        enemySpawnerMode.Spawn(target);
    }
}
