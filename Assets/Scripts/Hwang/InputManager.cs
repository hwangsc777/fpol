using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private PlayerControll playerControll;
    [SerializeField]
    private CameraControll cameraControll;
    [SerializeField]
    private GameObject crossHair;

    //나중에 풀링 오브젝트로 변경
    [SerializeField]
    private GameObject bullet;

    private void Awake()
    {
        //Application.targetFrameRate = 60;
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        playerControll.Move(h);
    }

    private void Update()
    {
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cameraControll.CameraMove(worldMousePos, playerControll.transform);
        playerControll.SeeMousePosition(worldMousePos.x);
        crossHair.transform.position = new Vector2(worldMousePos.x, worldMousePos.y);

        if (Input.GetMouseButtonDown(0))
        {
            //나중에 풀링 오브젝트로 변경
            Vector3 bulletPos = new Vector3(playerControll.transform.position.x, playerControll.transform.position.y + 0.8f, 0);
            Vector3 target = worldMousePos - playerControll.transform.position;
            Instantiate(bullet, bulletPos, playerControll.transform.rotation).GetComponent<Bullet>().Init(target.normalized);
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

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerControll.DownJumpTrigger(true);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            playerControll.DownJumpTrigger(false);
        }
    }
}
