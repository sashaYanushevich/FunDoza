using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class SpawnModel : MonoBehaviour
{
    public static bool gamestatus;
    public GameObject Cube;
    public GameObject knife;
    public delegate void Delegat();

    public void Start() {
        gamestatus = true;
        Instantiate (knife,new Vector3(0f,-3.6f,0f),Quaternion.identity);
        var obj=GameObject.FindGameObjectWithTag("knife");
        if(obj!=null)obj.SetActive(true);
        StartCoroutine(Spawner());
    }

    public void RunSpawner(){
        StartCoroutine(Spawner());
    }

    public IEnumerator Spawner() {
        var ch=Random.Range(0.8f,1.8f);
        yield return new WaitForSeconds(ch);
        Instantiate (Cube,new Vector3(4.5f,1.3f,-2.0f),Quaternion.identity);
        if(!knife.activeSelf){
            knife.SetActive(true);
        }
        if(gamestatus)
            StartCoroutine(Spawner());
    }
}
