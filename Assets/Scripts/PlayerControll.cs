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
    private Transform gunPos;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private SpriteRenderer gunSprite;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Animator fireEffect;
    [SerializeField]
    private GameObject bullet;

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

    private bool isWalk;
    private bool doubleJump;

    public void MouseClickEvent(Vector3 mousePos)
    {
        fireEffect.Play("fire", -1, 0f);
        SoundManager.Instance.PlaySource(AudioClips.shoot);

        float x = mousePos.x - gunPos.position.x;
        float y = mousePos.y - gunPos.position.y;

        float multiple = x >= y ? 1 / x : 1 / y;
        Vector3 target = new Vector3(x * multiple, y * multiple, 0);
        if (x < 0 && y < 0)
            target = new Vector3(target.x * -1, target.y * -1, 0);

        GameObject gameObject = Instantiate(bullet, gunPos.transform.position, gunPos.rotation);
        gameObject.GetComponent<Bullet>().Init(target.normalized);
    }

    public void SeeMousePosition(Vector3 mousePos)
    {
        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg;
        gunSprite.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (spriteRenderer.flipX)
        {
            if (mousePos.x > transform.position.x)
            {
                gunSprite.flipY = false;
                spriteRenderer.flipX = false;
                gunPos.Translate(0, 0.4f, 0);
            }
        }
        else
        {
            if (mousePos.x <= transform.position.x)
            {
                gunSprite.flipY = true;
                spriteRenderer.flipX = true;
                gunPos.Translate(0, -0.4f, 0);
            }
        }
    }

    public void Move(float horizontal)
    {
        rigid.AddForce(Vector2.right * horizontal * moveSpeed, ForceMode2D.Impulse);
        rigid.velocity = new Vector2(Mathf.Clamp(rigid.velocity.x, -maxMoveSpeed, maxMoveSpeed), Mathf.Clamp(rigid.velocity.y, -maxJumpSpeed, maxJumpSpeed));
        if(horizontal == 0)
        {
            if(isWalk == true)
            {
                isWalk = false;
                animator.SetBool("isWalk", false);
            }
        }
        else
        {
            if(isWalk == false)
            {
                isWalk = true;
                animator.SetBool("isWalk", true);
            }
        }
    }

    public void Jump()
    {
        if(rigid.velocity.y == 0)
        {
            rigid.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
        else
        {
            if(doubleJump == false)
            {
                doubleJump = true;
                rigid.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            }
        }
    }

    private void Update()
    {
        if (rigid.velocity.y == 0)
            doubleJump = false;
    }

    public void BreakMove()
    {
        rigid.velocity = new Vector2(0, rigid.velocity.y);
    }
}
