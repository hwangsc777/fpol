using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPath : MonoBehaviour
{
    public Vector2 pos, enemydir;
    public GameObject player;
    public Collider2D col;

    float xdif, ydif;
    public float speed = 1.0f;

    //애니메이션 관련
    //public Animator anim;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
  //      anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        //WhoIsUsing();
    }

    private void Update()
    {
        pos = col.bounds.center;
        Distence(player, out xdif, out ydif);
        Dir(player, out enemydir);
    }

    public void SetCollider(Collider2D chCol)
    {
        col = chCol;
    }

    public void MoveX()
    {

        if (xdif >= 0.5f)
        {
            transform.Translate(Vector2.right * speed * Time.fixedDeltaTime);
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            //anim.SetBool("isWalking", true);
        }
        else if (xdif < -0.5f)
        {
            transform.Translate(Vector2.left * speed * Time.fixedDeltaTime);
            transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            //anim.SetBool("isWalking", true);

        }
        else
        {
            //anim.SetBool("isWalking", false);
        }

    }

    public void MoveXY()
    {
        if (enemydir.magnitude > 0.5f)
        {
            //Debug.DrawRay(col.bounds.center, enemydir, new Color(0, 1, 0));
            transform.Translate(enemydir.normalized.x * speed * Time.fixedDeltaTime, enemydir.normalized.y * speed * Time.fixedDeltaTime, 0);
            //Debug.Log("movexy");
            //anim.SetBool("isWalking", true);
        }
        else 
        {
            //anim.SetBool("isWalking", false);
        }
    }
    public void RunAway()
    {
        //isWalking 값 따로 false로 설정해 줘야 함
        if (xdif < 0.5f)
        {
            transform.Translate(Vector2.right * speed * Time.fixedDeltaTime);
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            //anim.SetBool("isWalking", true);
        }
        else if (xdif >= -0.5f)
        {
            transform.Translate(Vector2.left * speed * Time.fixedDeltaTime);
            transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            //anim.SetBool("isWalking", true);
        }

    }
    public void RunAway(float spd)
    {
        //isWalking 값 따로 false로 설정해 줘야 함
        if (xdif < 0.5f)
        {
            transform.Translate(spd * Vector2.right * speed * Time.fixedDeltaTime);
            transform.localScale = new Vector3(spd * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            //anim.SetBool("isWalking", true);
        }
        else if (xdif >= -0.5f)
        {
            transform.Translate(spd * Vector2.left * speed * Time.fixedDeltaTime);
            transform.localScale = new Vector3(-1f * spd * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            //anim.SetBool("isWalking", true);
        }

    }
    public void WhoIsUsing()
    {
        Debug.Log(col.name);

    }

    void Distence(GameObject obj, out float xdif, out float ydif)
    {
        xdif = obj.transform.position.x - pos.x;
        ydif = obj.transform.position.y - pos.y;
        //Debug.Log(this.gameObject.name + " x좌표 차이 : " + xdif + " y좌표 차이 : " + ydif);
    }

    public void Dir(GameObject obj, out Vector2 dir)
    {
        dir = obj.transform.position - col.bounds.center;
        //Debug.Log("dir");
    }

}
