using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Move : MonoBehaviour
{
    Rigidbody2D rigid;
    public int NextMove;
    Animator animator;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
        Invoke("Think", 3);
    }


    void FixedUpdate()
    {   // Monster_Move
        rigid.velocity = new Vector2(NextMove, rigid.velocity.y);

        // PlatForm_Check
        Vector2 FrontVector = new Vector2(rigid.position.x + NextMove*0.3f, rigid.position.y);
        Debug.DrawRay(FrontVector, Vector3.down, Color.red);
        RaycastHit2D rayHit = Physics2D.Raycast(FrontVector, Vector3.down, 1, LayerMask.GetMask("Platform"));
        if(rayHit.collider == null)          
            turn();
    }

    void Think()
    {   //Random Move
        NextMove = Random.Range(-1, 2);

        animator.SetInteger("WalkSpeed", NextMove);

        if(NextMove != 0)
            spriteRenderer.flipX = NextMove == 1;
        
        Invoke("Think", 3);
    }

    void turn()
    {
        NextMove *= -1;
        spriteRenderer.flipX = NextMove == 1;

        CancelInvoke();
        Invoke("Think", 3);
    }
}

 