using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public int StageIndex;
    public Player_move player;
    public GameObject[] Tilemap;

    public void NextStage()
    { 
        Tilemap[StageIndex].SetActive(false);
        StageIndex ++; 
        Tilemap[StageIndex].SetActive(true);
        PlayerReposition();
    }


    void PlayerReposition(){
         
    player.transform.position = new Vector3(0,0,-1);

    }
}

