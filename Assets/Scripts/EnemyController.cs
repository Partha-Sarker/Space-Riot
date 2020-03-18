using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public IFireBehavior fireBehavior;
    public Transform gun;
    public Transform fireMode;

    private void Start()
    {
        fireBehavior = fireMode.GetComponent<EnemyBasicFire>();
    }

    // Update is called once per frame
    void Update()
    {
        fireBehavior.Fire(gun);
    }
}
