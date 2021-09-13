using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    public Game_Manager game_manager;
    public float MaxSpeed;
    public float JumpPower;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator animator;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    
    }

    void Update() //단발적인 입력에 좋음.
    {   
        //Sprite Direction Switch
        if(Input.GetButton("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

        //Walk Animation
        if(Mathf.Abs(rigid.velocity.x) < 0.3)
            animator.SetBool("IsWalking", false);
        else
            animator.SetBool("IsWalking", true);

        //Jump
        if(Input.GetButtonDown("Jump") && !animator.GetBool("IsJump")){
            rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            animator.SetBool("IsJump", true);
        }
    
    }

    
    void FixedUpdate()
    {
        //Player Move
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h * rigid.gravityScale, ForceMode2D.Impulse);
        
        //Player Max Speed
        if(rigid.velocity.x > MaxSpeed) //Right
            rigid.velocity = new Vector2(MaxSpeed, rigid.velocity.y);
        else if(rigid.velocity.x < MaxSpeed*(-1)) //Left
            rigid.velocity = new Vector2(MaxSpeed*(-1), rigid.velocity.y);

        //Landing Platform
        Debug.DrawRay(rigid.position, Vector3.down, new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
        if(rayHit.collider != null) {
            if(rayHit.distance < 0.5f)
                animator.SetBool("IsJump", false);
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy") 
            OnDamaged(collision.transform.position);   
        else if (collision.gameObject.tag == "Finish"){
            Debug.Log("피니시 닿았습니다.");
            game_manager.NextStage();
        }
        
        
    }

    void OnDamaged(Vector2 targetPos)

    {   //Change layer
        gameObject.layer = 8;

        //View Alpha
        spriteRenderer.color = new Color(1,1,1,0.4f);

        //Reaction Force
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc,1)*7 ,ForceMode2D.Impulse);

        Invoke("OffDamaged", 2);

    }

    void OffDamaged()
    {
        gameObject.layer = 3; 
        spriteRenderer.color = new Color(1,1,1,1);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        
    }
 

}
