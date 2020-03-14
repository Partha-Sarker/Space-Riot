using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultFire : MonoBehaviour, IFireBehavior
{
    public GameObject bullet;
    public int bulletForce = 50;
    public float defaultFireRate = 10;
    private float currentFireRate, nextTimeToFire = 0;

    private void Start()
    {
        currentFireRate = defaultFireRate;
    }

    

    public void Fire()
    {
        if (Time.time < nextTimeToFire)
            return;

        nextTimeToFire = Time.time + 1 / currentFireRate;
        GameObject releasedBullet = Instantiate(bullet, transform.position, transform.rotation);
        Rigidbody2D rb = releasedBullet.GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(Vector3.up * bulletForce, ForceMode2D.Impulse);
        Destroy(releasedBullet, 2);
    }

}
