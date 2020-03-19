using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour, IDamagable
{
    private Rigidbody2D rb;
    Vector2 mouse_pos, object_pos, velocity;
    public float angle, xInput, yInput, speed = 1;
    public Transform fireModes, gun;
    public IFireBehavior fireBehavior;
    public GameObject blastEffect;

    public int maxHealth = 500;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fireBehavior = fireModes.GetComponent<DefaultFire>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        mouse_pos = Input.mousePosition;
        object_pos = Camera.main.WorldToScreenPoint(transform.position);
        mouse_pos.x -= object_pos.x;
        mouse_pos.y -= object_pos.y;

        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg - 90;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (Input.GetButton("Fire1"))
        {
            fireBehavior.Fire(gun);
        }
    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        velocity.x = xInput;
        velocity.y = yInput;
        rb.velocity = velocity * speed;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
            SelfDestruct();
    }

    private void SelfDestruct()
    {
        GameObject blast = Instantiate(blastEffect, transform.position, Quaternion.identity);
        Destroy(blastEffect, 2);
        Destroy(gameObject);
    }
}
