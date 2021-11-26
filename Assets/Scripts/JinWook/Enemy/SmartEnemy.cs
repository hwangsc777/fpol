using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartEnemy : MonoBehaviour
{

    private OldPath script;

    Vector2 pos;
    GameObject player;

    float xdif, ydif;
    bool touch = false;

    [SerializeField]
    float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        pos = this.gameObject.transform.position;
        if (touch == false)
        {
            Distence(player, out xdif, out ydif);
            if (ydif <= 1.0f || ydif >= -1.0f)
            {
                MoveX();
            }else
            {
                FindPath();
            }
        }

    }

    void Distence(GameObject obj, out float xdif, out float ydif)
    {
        xdif = obj.transform.position.x - pos.x;
        ydif = obj.transform.position.y - pos.y;
        //Debug.Log(this.gameObject.name + " x좌표 차이 : " + xdif+" y좌표 차이 : " + ydif);
    }

    void MoveX()
    {

        if (xdif >= 0)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if (xdif < 0)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

    }

    void FindPath()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.touch = true;
            //Debug.Log(other.name + " 충돌 감지");
        }

    }
    /*
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                Debug.Log(other.gameObject.name + " 충돌 감지");
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
