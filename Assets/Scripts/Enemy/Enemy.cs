using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //???? ????
    public bool touch = false;
    private float hp;

    public GameObject player;
    //?? ??
    public MonsterManager monsterManager;

    protected OldPath oPath;


    public Floor enemyfloor;
    public static Floor playerfloor;
    public bool setJump;
    public string jumpTarget;

    protected virtual void Start()
    {
        oPath = GetComponent<OldPath>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (hp <= 0)
        {
            //Destroy(gameObject);
        }
    }

    //HP ????
    protected void SetHp(float num)
    {
        hp = num;
    }

    public void Damage(float dmg)
    {
        hp -= dmg;
    }


    //???? ????
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.touch = true;
            //Debug.Log(other.name + " Enter");
        }

    }

    /*
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                Debug.Log(other.gameObject.name + " ???? ????");
            }
        }
    */
    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.touch = false;
            //Debug.Log(other.name + " Exit");
        }

    }
}
