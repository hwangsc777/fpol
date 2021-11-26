using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool touch = false;
    public GameObject player;
    private float hp;

    void Start()
    {
        player = GameObject.Find("Player");

    }

    private void FixedUpdate()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    //HP ����
    protected void SetHp(float num)
    {
        hp = num;
    }

    public void Damage(float dmg)
    {
        hp -= dmg;
    }


    //�浹 ����
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.touch = true;
            //Debug.Log(other.name + " �浹");
        }

    }
    /*
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                Debug.Log(other.gameObject.name + " �浹 ����");
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                this.touch = false;
            }
        }*/
}
