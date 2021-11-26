using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigid;
    [SerializeField]
    private BoxCollider2D boxCollider;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private SpriteRenderer gunSprite;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float maxMoveSpeed;
    [SerializeField]
    private float jumpSpeed;
    [SerializeField]
    private float maxJumpSpeed;
    [SerializeField]
    private float maxJumpRange;
    [SerializeField]
    private int jumpAbleTime;

    private bool downJumpAble;
    private GameObject standingFloor;

    public void SeeMousePosition(float x)
    {
        if(!spriteRenderer.flipX && x < transform.position.x)
        {
            SpriteFlip();
        }
        else if(spriteRenderer.flipX && x >= transform.position.x)
        {
            SpriteFlip();
        }
    }

    void SpriteFlip()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
        gunSprite.flipX = !gunSprite.flipX;
        gunSprite.transform.Translate(gunSprite.flipX ? 1.6f : -1.6f, 0, 0);
    }

    public void Move(float horizontal)
    {
        rigid.AddForce(Vector2.right * horizontal * moveSpeed, ForceMode2D.Impulse);
        rigid.velocity = new Vector2(Mathf.Clamp(rigid.velocity.x, -maxMoveSpeed, maxMoveSpeed), Mathf.Clamp(rigid.velocity.y, -maxJumpSpeed, maxJumpSpeed));
    }

    public void Jump()
    {
        if (downJumpAble)
        {
            boxCollider.isTrigger = true;
        }
        else
        {
            rigid.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
    }

    public void BreakMove()
    {
        rigid.velocity = new Vector2(0, rigid.velocity.y);
    }

    public void DownJumpTrigger(bool downJumpAble)
    {
        this.downJumpAble = downJumpAble;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "DownJumpAbleFloor")
        {
            if (transform.position.y + 0.25f > collision.transform.position.y)
                boxCollider.isTrigger = false;
        }
        else
        {
            boxCollider.isTrigger = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.tag != "Enemy")
        {
            if(collision.transform.tag != "Wall")
            {
                boxCollider.isTrigger = true;
            }
        }
    }
}
