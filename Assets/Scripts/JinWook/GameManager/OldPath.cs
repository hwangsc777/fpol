using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPath : MonoBehaviour
{
    Vector2 pos, enemydir;
    GameObject player;
    public GameObject UsingObj;

    float xdif, ydif;
    public float speed = 1.0f;

    private void Start()
    {
        player = GameObject.Find("Player");
        UsingObj = gameObject;
        //WhoIsUsing();
    }

    private void Update()
    {
        pos = UsingObj.gameObject.transform.position;
        Distence(player, out xdif, out ydif);
        Dir(player, out enemydir);
    }

    public void SetObject(GameObject obj)
    {
        UsingObj = obj;
    }

    public void MoveX()
    {

        if (xdif >= 0)
        {
            UsingObj.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if (xdif < 0)
        {
            UsingObj.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

    }

    public void MoveXY()
    {
        UsingObj.transform.Translate(enemydir.normalized.x * speed * Time.deltaTime, enemydir.normalized.y * speed * Time.deltaTime, 0);
        //Debug.Log("movexy");
    }

    public void WhoIsUsing()
    {
        Debug.Log(UsingObj.name);

    }

    void Distence(GameObject obj, out float xdif, out float ydif)
    {
        xdif = obj.transform.position.x - pos.x;
        ydif = obj.transform.position.y - pos.y;
        //Debug.Log(this.gameObject.name + " xÁÂÇ¥ Â÷ÀÌ : " + xdif + " yÁÂÇ¥ Â÷ÀÌ : " + ydif);
    }

    void Dir(GameObject obj, out Vector2 dir)
    {
        dir = obj.transform.position - UsingObj.gameObject.transform.position;
        //Debug.Log("dir");
    }


}
