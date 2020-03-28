﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Bullet : MonoBehaviour
{
    public int initialDamage = 30;
    public int currentDamage;

    private void Start()
    {
        currentDamage = initialDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            collision.GetComponent<IDamagable>().TakeDamage(currentDamage);
            Destroy(gameObject);
        }
        catch (Exception)
        {
            return;
        }
    }
}
