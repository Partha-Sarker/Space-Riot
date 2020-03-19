using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamagable
{
    public IFireBehavior fireBehavior;
    public Transform gun;
    public Transform fireMode;
    public GameObject blastParticle;

    private int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        fireBehavior = fireMode.GetComponent<EnemyBasicFire>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        fireBehavior.Fire(gun);
        if (Input.GetKeyDown(KeyCode.F))
            TakeDamage(120);
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
