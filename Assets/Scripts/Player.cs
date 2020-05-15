using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{//이동, 방향전환, 애니메이션

    private Rigidbody2D rigid;
    private SpriteRenderer sprite;
    private Animator ani;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();

        if (rigid.velocity.x != 0)
            ani.SetBool("isWalking", true);
        else
            ani.SetBool("isWalking", false);
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");

        rigid.velocity = new Vector2(h, 0);
    }

    void Flip()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
            sprite.flipX = false;
        else if (Input.GetAxisRaw("Horizontal") < 0)
            sprite.flipX = true;
    }
}
