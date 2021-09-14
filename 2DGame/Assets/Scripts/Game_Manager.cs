using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public int StageIndex;
    public Player_move player;
    public GameObject[] Stages;
    
    public void NextStage()
    {   
        if(StageIndex < Stages.Length -1 ){
            Stages[StageIndex].SetActive(false);
            StageIndex ++; 
            Stages[StageIndex].SetActive(true);
            PlayerReposition();
        }
        else{
            Time.timeScale = 0; 
        }
    }


    void PlayerReposition(){
         
    player.transform.position = new Vector3(0,0,-1);

    }
}

