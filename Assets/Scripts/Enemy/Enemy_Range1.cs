/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Range1 : Enemy
{
    CircleCollider2D chCol;
    bool toPlayer = true;
    bool stuckInWall;
    Vector2 exitWallStuck;

    float atkSpd = 2.0f;
    float temp = 0f;

    Arrow arrowScript;
    public GameObject arrow;
    public GameObject arrowPos;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        chCol = GetComponent<CircleCollider2D>();
        arrowScript = arrow.GetComponent<Arrow>();
        SetHp(3);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        temp += Time.fixedDeltaTime;
        if (temp > atkSpd)
        {
            temp = 0f;

            if (oPath.anim.GetBool("isAttacking"))
            {
                oPath.anim.SetBool("isAttacking", false);
            } else
            {
                Shoot();
                oPath.MoveX();
                oPath.anim.SetBool("isWalking", false);
                oPath.anim.SetBool("isAttacking", true);
            }

        }
        if (toPlayer == true)
        {

        }
        else 
        {
            oPath.anim.SetBool("isAttacking", false);
            oPath.RunAway();
            if(stuckInWall == true)
            {
                //rb.AddForce(Vector2.up * 50);
                // circle콜라이더에 벽과 플레이어가 3초 이상 충돌(벽과 플레이어 사이에 낑긴 경우) 시 취할 행동 작성
                Debug.Log("StuckInWall");
            }
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.tag == "Player")
        {
            SettoPlayerOff();
            //Debug.Log(other.name + " Enter");
        } else if (other.tag == "Wall" && toPlayer == false)
        {
            ExitWallStuck();
            Invoke("StuckInWallOn", 3);
        }

    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);
        if (other.tag == "Player")
        {
            Invoke("SettoPlayerOn", 1f);
            //Debug.Log(other.name + " Exit");
            StuckInWallOff();
        }
    }

    void Shoot()
    {
        //Debug.Log("Shoot");
        Vector2 createPos = arrowPos.transform.position;
        oPath.Dir(player, out Vector2 target);
        target.y += 1f;
        float angle = (Mathf.PI + Mathf.Atan2(target.y, target.x)) * Mathf.Rad2Deg;
        Instantiate(arrow, createPos, Quaternion.AngleAxis(angle, Vector3.forward)).GetComponent<Arrow>().Init(target);

    }




    void ExitWallStuck()
    {
        exitWallStuck = player.transform.position - transform.position;
    }

    void SettoPlayerOn()
    {
        toPlayer = true;
        oPath.MoveX();
        oPath.anim.SetBool("isWalking", false);
    }
    void SettoPlayerOff()
    { 
        toPlayer = false;
    }
    void StuckInWallOn()
    {
        stuckInWall = true;
    }
    void StuckInWallOff()
    {
        stuckInWall = false;
    }


}
*/