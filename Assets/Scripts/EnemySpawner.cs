using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    ISpawningBehavior enemySpawner;
    public Transform spawnMode, target;

    private void Start()
    {
        enemySpawner = spawnMode.GetComponent<DefaultEnemySpawn>();
        enemySpawner.Spawn(target);
    }
}
