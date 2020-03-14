using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultFire : MonoBehaviour, IFireBehavior
{
    public GameObject bullet;
    public int bulletForce = 5000;
    public float defaultFireRate = 5;

    [SerializeField]
    private float currentFireRate;

    private float nextTimeToFire = 0;

    private void Start()
    {
        currentFireRate = defaultFireRate;
    }

    

    public void Fire(Transform parent)
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
