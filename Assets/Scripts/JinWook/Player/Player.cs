using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string floorPos;

    /*Vector2 pos;

    
    private void Awake()
    {
        pos = this.gameObject.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }*/

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Floor1")
        {
            floorPos = "Floor1";
            Debug.Log("�÷��̾��� ��ġ : " + floorPos);
        }
        else if (other.gameObject.name == "Floor2L")
        {
            floorPos = "Floor2L";
            Debug.Log("�÷��̾��� ��ġ : " + floorPos);

        }
        else if (other.gameObject.name == "Floor2R")
        {
            floorPos = "Floor2R";
            Debug.Log("�÷��̾��� ��ġ : " + floorPos);
        }
        else
        {
            floorPos = "Unknown";
            Debug.Log("�÷��̾��� ��ġ : " + floorPos);

        }
    }

}
