using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigid;
    [SerializeField]
    private float speed;

    private Vector3 target;

    public void Init(Vector3 target)
    {
        this.target = target;
    }

    private void Update()
    {
        rigid.velocity = target * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Enemy":
                SoundManager.Instance.PlaySource(AudioClips.hit);
                collision.gameObject.GetComponent<Enemy>().monsterManager.CheckMonster(collision.gameObject);
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case "Wall":
                //나중에 풀링 오브젝트로 변경하기
                Destroy(gameObject);
                break;
            case "Ground":
                //나중에 풀링 오브젝트로 변경하기
                Destroy(gameObject);
                break;
            default:

                break;
        }
    }
}
