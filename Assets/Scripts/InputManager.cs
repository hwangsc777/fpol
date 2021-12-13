using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private PlayerControll playerControll;
    [SerializeField]
    private GameObject crossHair;

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        playerControll.Move(h);
    }

    private void Update()
    {
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerControll.SeeMousePosition(worldMousePos);
        crossHair.transform.position = new Vector2(worldMousePos.x, worldMousePos.y);

        if (Input.GetMouseButtonDown(0))
        {
            playerControll.MouseClickEvent(worldMousePos);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerControll.Jump();
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            playerControll.BreakMove();
        }

        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            playerControll.BreakMove();
        }
    }
}
