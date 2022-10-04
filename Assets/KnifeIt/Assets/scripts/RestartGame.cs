using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    public Text textscorre;
    public Text textllives;
    public GameObject knifee;
    public GameObject panell;
    public GameObject enemyy;
    public GameObject Spawnr;

    public void RestartGameFunc(){
        DestroyByHit.score=0;
        DestroyScr.livesofman=3;
        textscorre.GetComponent<Text>().text="Score: "+DestroyByHit.score;
        textllives.GetComponent<Text>().text="Lives: "+DestroyScr.livesofman;
        SpawnModel.gamestatus=true;
        panell.SetActive(false);
        knifee.SetActive(true);
        enemyy.SetActive(true);
        Spawnr.SetActive(true);
        StartCoroutine(Spawnr.GetComponent<SpawnModel>().Spawner());
        Instantiate (knifee,new Vector3(0f,-3.6f,0f),Quaternion.identity);
    }
}