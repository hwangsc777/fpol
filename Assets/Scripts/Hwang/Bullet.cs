using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigid;
    [SerializeField]
    private float speed;

    private Vector3 target;

    public void Init(Vector3 target)
    {
        this.target = target;
    }

    private void Update()
    {
        rigid.velocity = target * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }

        if(collision.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
