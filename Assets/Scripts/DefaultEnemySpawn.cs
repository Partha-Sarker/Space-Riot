using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemySpawn : MonoBehaviour, ISpawningBehavior
{
    public GameObject baseEnemy;
    [SerializeField]
    private float defaultDelay = 1, selfDestructionTime = 10;
    [HideInInspector]
    public float currentDelay;

    public int minimumDistance = 50;
    private int randomAngle;
    private float randomX, randomY, angle;


    private void Start()
    {
        currentDelay = defaultDelay;
    }

    public void Spawn(Transform target)
    {
        StartCoroutine(Spawning(target));
    }

    IEnumerator Spawning(Transform target)
    {
        randomAngle = Random.Range(0, 359);
        randomX = target.position.x + minimumDistance * Mathf.Cos(randomAngle);
        randomY = target.position.y + minimumDistance * Mathf.Sin(randomAngle);
        angle = Mathf.Atan2(randomY-target.position.y, randomX - target.position.x) * Mathf.Rad2Deg + 90;
        GameObject spawnedEnemy = Instantiate(baseEnemy, new Vector2(randomX, randomY), Quaternion.Euler(0, 0, angle));
        Destroy(spawnedEnemy, selfDestructionTime);

        yield return new WaitForSeconds(currentDelay);
        StartCoroutine(Spawning(target));
    }
}
