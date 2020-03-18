using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicFire : MonoBehaviour, IFireBehavior
{

    public GameObject enemyBullet;
    public int bulletForce = 35;
    public float defaultFireRate = 2;
    private float currentFireRate, nextTimeToFire = 0;

    private void Start()
    {
        currentFireRate = defaultFireRate;
    }

    public void Fire(Transform gunPosition)
    {
        if (Time.time < nextTimeToFire)
            return;
        nextTimeToFire = Time.time + 1 / currentFireRate;
        GameObject releasedBullet = Instantiate(enemyBullet, gunPosition.position, gunPosition.rotation);
        Rigidbody2D rb = releasedBullet.GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(Vector3.up * bulletForce, ForceMode2D.Impulse);
        Destroy(releasedBullet, 2);
    }
}
