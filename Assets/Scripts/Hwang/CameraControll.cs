using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    [SerializeField]
    private Vector2 maxXY;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxSpeed;

    private float xVelocity;
    private float yVelocity;


    public void CameraMove(Vector2 worldMousePos, Transform playerPos)
    {
        float x = Mathf.Clamp(Mathf.SmoothDamp(transform.position.x, worldMousePos.x, ref xVelocity, speed, maxSpeed), playerPos.position.x - maxXY.x, playerPos.position.x + maxXY.x);
        float y = Mathf.Clamp(Mathf.SmoothDamp(transform.position.y, worldMousePos.y, ref yVelocity, speed, maxSpeed), playerPos.position.y - maxXY.y, playerPos.position.y + maxXY.y);

        transform.position = new Vector3(x, y, -10);
    }
}
