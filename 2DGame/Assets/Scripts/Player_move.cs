using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    public float MaxSpeed;
    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        //Player Move
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
        
        //Player Max Speed
        if(rigid.velocity.x > MaxSpeed) //Right
            rigid.velocity = new Vector2(MaxSpeed, rigid.velocity.y);
        else if(rigid.velocity.x < MaxSpeed*(-1)) //Left
            rigid.velocity = new Vector2(MaxSpeed*(-1), rigid.velocity.y);
        
    }
}
