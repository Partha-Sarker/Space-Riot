using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            collision.GetComponent<IDamagable>().TakeDamage(30);
            Destroy(gameObject);
        }
        catch (Exception)
        {
            return;
        }
    }
}
