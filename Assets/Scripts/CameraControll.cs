using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    [SerializeField]
    Transform playerPos;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxSpeed;

    private Vector2 maxXY;
    private float xVelocity;
    private float yVelocity;

    private void Start()
    {
        float height = Camera.main.orthographicSize * 2;
        float width = Camera.main.aspect * height;

        maxXY.x = width / 2 * 1.2f;
        maxXY.y = height * 0.6f;
    }

    private void Update()
    {
        float targetX = (Input.mousePosition.x / Screen.width * 2 - 1) * maxXY.x;
        float targetY = (Input.mousePosition.y / Screen.height * 2 - 1) * maxXY.y;
        float x = Mathf.Clamp(Mathf.SmoothDamp(transform.position.x, targetX, ref xVelocity, speed, maxSpeed), playerPos.position.x - maxXY.x, playerPos.position.x + maxXY.x);
        float y = Mathf.Clamp(Mathf.SmoothDamp(transform.position.y, targetY, ref yVelocity, speed, maxSpeed), playerPos.position.y - maxXY.y + 1, playerPos.position.y + maxXY.y + 1);

        transform.position = new Vector3(x, y, -10);
    }
}
