using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Air1 : Enemy
{
    bool stop = false;
    bool mov = false;
    float speedX;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        SetHp(3);
        speedX = oPath.speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*if (touch == true && stop == false)
        {
          //  oPath.anim.SetBool("isReady", true);
            stop = true;
            Invoke("Attack", 2);
        }
        else if (touch == false)
        {
            stop = false;
            mov = false;
       //     oPath.anim.SetBool("isReady", false);
        //    oPath.anim.SetBool("isAttack", true);
        //    oPath.anim.SetBool("isAttack", false);
            oPath.speed = speedX;
            oPath.MoveXY();
        }*/

        //if(mov == true)
        {
            oPath.MoveXY();
        }
        //Debug.DrawRay(oPath.col.bounds.center, oPath.enemydir, new Color(0, 1, 0));
    }

    void Attack()
    {
       // oPath.anim.SetBool("isReady", false);
     //  oPath.anim.SetBool("isAttack", true);
        oPath.speed = 5*speedX;
        mov = true;
        
    }
}
