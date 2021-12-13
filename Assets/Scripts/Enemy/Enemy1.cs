using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    protected override void Start()
    {
        base.Start();
        SetHp(5);
    }
    void Update()
    {

    }
}
