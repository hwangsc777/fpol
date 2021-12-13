/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Melee3 : Enemy
{

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        SetHp(3);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (touch == true)
        {
            oPath.anim.SetBool("isAttacking", true);
        }
        else
        {
            oPath.anim.SetBool("isAttacking", false);
            oPath.MoveX();
        }
    }
}
*/