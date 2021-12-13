using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "skeleton(Clone)")
        {
            Enemy es = collision.gameObject.GetComponent<Enemy>();
            Rigidbody2D rg = collision.gameObject.GetComponent<Rigidbody2D>();
            if (es.setJump == true)
            {
                rg.AddForce(Vector2.up * 25, ForceMode2D.Impulse);
                es.enemyfloor += 1;
            }

        }
    }


}
