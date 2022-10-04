using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProcess : MonoBehaviour
{

    public GameObject stepfloor;
    Vector3 laststep;
    Vector3 neededstep;
    public float checkRadius=0.3f;
    public LayerMask Ground;
    public Transform GroundCheck;
    public Text scoree;
    public Camera ghostcam;
    public static int score;
    float dumping = 0.7f;
    int counter=0;

    void Start()
    {
        ghostcam.enabled=false;
        score=0;
        laststep=GameObject.FindGameObjectWithTag("Floor").transform.position;
        var obj=GameObject.FindGameObjectWithTag("hero");
        Instantiate(stepfloor,new Vector3(Random.Range(obj.transform.position.x+1.55f,obj.transform.position.x+3f),Random.Range(obj.transform.position.y-1.2f,obj.transform.position.y+4.5f),0f),Quaternion.identity);
    }

    void Update()
    {
        if(CheckFloor() & Camera.main.transform.position!=GameObject.FindGameObjectWithTag("GhostCamera").transform.position){
            CheckForScore();
        }
    }
    public bool CheckFloor(){
        return Physics2D.OverlapCircle(GroundCheck.position,checkRadius,Ground);
    }

    public void CheckForScore(){
        GameObject[] floors=GameObject.FindGameObjectsWithTag("Floor");
        neededstep=floors[floors.Length-1].transform.position;
        if(Vector3.Distance(neededstep,GameObject.FindGameObjectWithTag("hero").transform.position)<1f){
            if(Vector3.Distance(neededstep,laststep)>0.5f){
                score+=1;
                counter+=1;
                CheckForSpamPanels();
                scoree.GetComponent<Text>().text="Score: "+score;
                laststep=neededstep;
                var obj=GameObject.FindGameObjectWithTag("hero");
                Instantiate(stepfloor,new Vector3(Random.Range(obj.transform.position.x+1.55f,obj.transform.position.x+3f),Random.Range(obj.transform.position.y-1.2f,obj.transform.position.y+4.5f),0f),Quaternion.identity);
                CameraController.movecam=true;
            }
        }
        else CameraController.neededpos=GameObject.FindGameObjectWithTag("GhostCamera").transform.position;
    }

    public void CheckForSpamPanels(){
        GameObject[] floors=GameObject.FindGameObjectsWithTag("Floor");
        int k=0;
        if(floors.Length>7)
        {
            foreach(GameObject o in floors){
                Destroy(o.gameObject);
                k++;
                if(k>5){
                    counter=0;
                    break;
                }
            }
        }
    }
}
