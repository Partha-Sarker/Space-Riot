using Cinemachine;
using UnityEngine;

public class DefaultFire : MonoBehaviour, IFireBehavior
{
    public GameObject bullet;
    private CinemachineImpulseSource cinemachineImpulse;
    public int bulletForce = 50;
    public float defaultFireRate = 10;
    private float currentFireRate, nextTimeToFire = 0;

    private void Start()
    {
        currentFireRate = defaultFireRate;
        cinemachineImpulse = GetComponentInParent<CinemachineImpulseSource>();
    }

    

    public void Fire(Transform gunPosition)
    {
        if (Time.time < nextTimeToFire)
            return;

        nextTimeToFire = Time.time + 1 / currentFireRate;
        GameObject releasedBullet = Instantiate(bullet, gunPosition.position, gunPosition.rotation);
        Rigidbody2D rb = releasedBullet.GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(Vector3.up * bulletForce, ForceMode2D.Impulse);
        Destroy(releasedBullet, 2);
    }

}
