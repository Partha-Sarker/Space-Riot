using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector2 mouse_pos, object_pos, velocity;
    public float angle, xInput, yInput, speed = 1;
    public Transform fireModes;
    IFireBehavior fireBehavior;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fireBehavior = fireModes.GetComponent<DefaultFire>();
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

        if (Input.GetMouseButton(0))
        {
            fireBehavior.Fire();
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
}
