using Cinemachine;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamagable
{
    public IFireBehavior fireBehavior;
    public Transform gun;
    public Transform fireMode;
    public GameObject blastParticle;
    private CinemachineImpulseSource impulse;

    private int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        fireBehavior = fireMode.GetComponent<EnemyBasicFire>();
        currentHealth = maxHealth;
        impulse = GetComponent<CinemachineImpulseSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("bullet"))
            impulse.GenerateImpulse();
    }

    // Update is called once per frame
    void Update()
    {
        fireBehavior.Fire(gun);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= maxHealth;
        if (currentHealth <= 0)
            BlastSelf();
    }

    private void BlastSelf()
    {
        GameObject blast = Instantiate(blastParticle, transform.position, Quaternion.identity);
        Destroy(blast, 2);
        Destroy(gameObject);
    }
}
