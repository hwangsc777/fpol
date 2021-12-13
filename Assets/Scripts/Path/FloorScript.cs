using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Floor { F1, F2, F3_L, F3_R };

public class FloorScript : MonoBehaviour
{ 

    public Floor curFloor;

    Floor Floorinfo()
    {
        return curFloor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Enemy.playerfloor = curFloor;
            Debug.Log("playerfloor = " + curFloor);   
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy es = collision.gameObject.GetComponent<Enemy>();
            es.enemyfloor = curFloor;
            Debug.Log("enemyfloor = " + curFloor);

        }
    }
}
