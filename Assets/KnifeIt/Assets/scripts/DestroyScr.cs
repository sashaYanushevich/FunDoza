using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyScr : MonoBehaviour
{
    public GameObject knife;
    public GameObject panel;
    public Text textLives;
    public GameObject Spawner;
    public Text UrRes;
    public Text Rcrd;
    

    public static int livesofman = 3;
    public void Start()
    {
        Spawner.SetActive(true);
        panel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "enemy")
            Destroy(other.gameObject);
        if (other.tag=="knife") {
            Destroy(other.gameObject);
            //isForce=false;
            Instantiate (knife,new Vector3(0f,-3.6f,0f),Quaternion.identity);
            if(livesofman>0){
                livesofman--;
                textLives.GetComponent<Text>().text="Lives: "+livesofman;
            }
            else{
                SpawnModel.gamestatus=false;
                knife.SetActive(false);
                panel.SetActive(true);
                Spawner.SetActive(false);
                GameObject[] knifes=GameObject.FindGameObjectsWithTag("knife");
                foreach(var kn in knifes){
                    Destroy(kn.gameObject);
                }
                UrRes.GetComponent<Text>().text="Your result: "+DestroyByHit.score;
                int recdata=0;
                if(PlayerPrefs.HasKey("LocalRecordKnife")){
                    recdata=PlayerPrefs.GetInt("LocalRecordKnife");
                }
                Rcrd.GetComponent<Text>().text="Record: "+recdata;
                if(recdata<DestroyByHit.score){
                    recdata=DestroyByHit.score;
                    PlayerPrefs.SetInt("LocalRecordKnife",recdata);
                    PlayerPrefs.Save();
                }                
            }
        }
    }
}
