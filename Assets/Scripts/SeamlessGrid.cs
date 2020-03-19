using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeamlessGrid : MonoBehaviour
{
    public Transform target;
    public float x, y;
    public int minMovement = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            x = target.position.x - (target.position.x % minMovement);
            y = target.position.y - (target.position.y % minMovement);
            transform.position = new Vector2(x, y);
        } catch (Exception)
        {
            return;
        }
    }
}
