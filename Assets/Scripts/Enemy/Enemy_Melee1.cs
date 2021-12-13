using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Melee1 : Enemy
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

        if (enemyfloor < playerfloor)
        {
            setJump = true;
            if(gameObject.transform.position.x <= 0f)
            {
                switch(enemyfloor)
                {
                    case Floor.F1:
                        oPath.player = GameObject.Find("UnderLeft");
                        jumpTarget = "MiddleLeft";
                        oPath.MoveX();
                        break;
                    case Floor.F2:
                        oPath.player = GameObject.Find("MiddleLeft");
                        jumpTarget = "TopLeft";
                        oPath.MoveX();
                        break;
                    case Floor.F3_L:
                        oPath.player = GameObject.Find("TopLeft");
                        oPath.MoveX();
                        break;
                }
            } else if (gameObject.transform.position.x > 0f)
            {
                switch (enemyfloor)
                {
                    case Floor.F1:
                        oPath.player = GameObject.Find("UnderRight");
                        jumpTarget = "MiddleRight";
                        oPath.MoveX();
                        break;
                    case Floor.F2:
                        oPath.player = GameObject.Find("MiddleRight");
                        jumpTarget = "TopRight";
                        oPath.MoveX();
                        break;
                    case Floor.F3_L:
                        oPath.player = GameObject.Find("TopRight");
                        oPath.MoveX();
                        break;
                }
            }

        } else if(enemyfloor >= playerfloor)
        {
            setJump = false;
            oPath.player = GameObject.FindGameObjectWithTag("Player");
            oPath.MoveX();
        }

        
    }
    
}
