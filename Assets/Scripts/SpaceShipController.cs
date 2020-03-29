using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class SpaceShipController : MonoBehaviour, IDamagable
{
    private Rigidbody2D rb;
    Vector2 mouse_pos, object_pos, velocity;
    public float speed = 1;
    public int dashSpeed = 50;
    public float dashTime = .3f, dashEndTime, dashCoolDownTime = 1f, dashCoolDownEndTime = 0;
    private float angle, xInput, yInput;
    public Transform fireModes, gun;
    public IFireBehavior fireBehavior;
    public GameObject blastEffect;
    public EnemySpawner enemySpawner;
    public ButtonManager buttonManager;

    [SerializeField]
    private CinemachineImpulseSource impulse;

    public int maxHealth = 500;
    public int currentHealth;

    private SpriteRenderer spriteRenderer;
    private Color color;

    private float time, lifePercent, startR, startG, startB, currentR, currentG, currentB;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fireBehavior = fireModes.GetComponent<DefaultFire>();
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
        startB = color.b;
        startR = color.r;
        startG = color.g;
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

        time = Time.time;

        if (Input.GetKeyDown(KeyCode.LeftShift) && time > dashCoolDownEndTime)
        {
            impulse.GenerateImpulse();
            dashEndTime = time + dashTime;
            dashCoolDownEndTime = time + dashCoolDownTime;
        }

    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        velocity.x = xInput;
        velocity.y = yInput;
        if(dashEndTime > Time.time)
            rb.velocity = velocity * dashSpeed;
        else
            rb.velocity = velocity * speed;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            SelfDestruct();
            currentHealth = 0;
        }
        lifePercent = (float) currentHealth / (float) maxHealth;

        currentR = startR + (1 - startR) * (1 - lifePercent);
        currentG = startG + (1 - startG) * (1 - lifePercent);
        currentB = startB + (1 - startB) * (1 - lifePercent);

        color = new Color(currentR, currentG, currentB);
        spriteRenderer.color = color;
    }

    private void SelfDestruct()
    {
        GameObject blast = Instantiate(blastEffect, transform.position, Quaternion.identity);
        Destroy(blast, 2);
        enemySpawner.SetNoSpawnMode();
        buttonManager.ActiveRetryButton();
    }
}
