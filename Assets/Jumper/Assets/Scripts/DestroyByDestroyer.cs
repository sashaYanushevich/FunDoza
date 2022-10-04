using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyByDestroyer : MonoBehaviour
{
    public bool OnDestroyer;
    public Transform DestroyerCheck;
    public float checkRadius=0.5f;
    public LayerMask Destroyer;
    public GameObject panel;
    public GameObject otherui;
    public GameObject floor;
    public Text restext;
    public Text recordtext;

    private void Start()
    {
        panel.SetActive(false);
    }

    public void CheckDestroyer(){
        OnDestroyer=Physics2D.OverlapCircle(DestroyerCheck.position,checkRadius,Destroyer);
        Debug.Log(OnDestroyer);
    }

    void FixedUpdate()
    {
        CheckDestroyer();
        if(OnDestroyer)EndGameRound();
    }

    public void EndGameRound(){
        Camera.main.transform.position=new Vector3(0f,0f,-10f);
        GameObject[] objects=GameObject.FindGameObjectsWithTag("Floor");
        foreach(GameObject obj in objects){
            Destroy(obj.gameObject);
        }
        Instantiate(floor,new Vector3(-1.2998f,-2.69f,0f),Quaternion.identity);//пол
        GameObject[] array = GameObject.FindGameObjectsWithTag("Destroyer");
        foreach(var obj in array){
            obj.SetActive(false);
        }
        GameObject.FindGameObjectWithTag("hero").GetComponent<Rigidbody2D>().velocity=Vector2.zero;
        GameObject.FindGameObjectWithTag("hero").transform.position=new Vector3(-1.2998f,-1.7957f,0f);
        var objjj=GameObject.FindGameObjectWithTag("hero");
        Instantiate(floor,new Vector3(Random.Range(objjj.transform.position.x+1.55f,objjj.transform.position.x+3f),Random.Range(objjj.transform.position.y-1.2f,objjj.transform.position.y+4.5f),0f),Quaternion.identity);
        restext.GetComponent<Text>().text="your result: "+GameProcess.score;
        int recdata=0;
        if(PlayerPrefs.HasKey("LocalRecordJumper")){
            recdata=PlayerPrefs.GetInt("LocalRecordJumper");
        }
        recordtext.GetComponent<Text>().text="Record: "+recdata;
        if(recdata<GameProcess.score){
            recdata=GameProcess.score;
            PlayerPrefs.SetInt("LocalRecordJumper",recdata);
            PlayerPrefs.Save();
        }                
        panel.SetActive(true);
        otherui.SetActive(false);
    }
}
