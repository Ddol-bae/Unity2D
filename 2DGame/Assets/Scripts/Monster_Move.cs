using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Move : MonoBehaviour
{
    Rigidbody2D rigid;
    public int NextMove;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Think();

        Invoke("Think", 3);
    }


    void FixedUpdate()
    {   // Monster_Move
        rigid.velocity = new Vector2(NextMove, rigid.velocity.y);

        // PlatForm_Check
        Vector2 FrontVector = new Vector2(rigid.position.x + NextMove, rigid.position.y);
        Debug.DrawRay(FrontVector, Vector3.down, new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(FrontVector, Vector3.down, 1, LayerMask.GetMask("Platform"));
        if(rayHit.collider == null) {
            Debug.Log("낭떠러지");
            
        }
    }

    void Think()
    {   //Random Move
        NextMove = Random.Range(-1, 2);

        Invoke("Think", 3);

    }
}
 