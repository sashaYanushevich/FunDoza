using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
     public GameObject goal1;
     public GameObject goal2;
     public Text ScoreText;
     static public int score ;
     private int tryCount;
     private int record;
     public AudioSource tapAudio;
     public AudioSource checkAudio;

     bool check = false;
     bool pointb = true;
     bool pointa = true;
    // Start is called before the first frame update
    void Start()
    {
       tryCount = PlayerPrefs.GetInt("tryCount");
       score = 0; 
    }

    // Update is called once per frame
    void Update()
    {

        if(check) {
            transform.position = Vector3.MoveTowards(transform.position,goal1.transform.position, 3f * Time.deltaTime);
        }
        if(!check) {
            transform.position = Vector3.MoveTowards(transform.position,goal2.transform.position, 3f * Time.deltaTime);
        }

        transform.rotation *= Quaternion.Euler(0f,0f,0.3f);

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "point") {
            change();
        }
        if(other.name == "point_b" && pointb == true){
             score++;
            ScoreText.GetComponent<Text>().text = "SCORE: "+score;
            checkAudio.Play();
            pointb = false;
            pointa = true;
        }
        if(other.name == "point_a" && pointa == true){
             score++;
             checkAudio.Play();
            ScoreText.GetComponent<Text>().text = "SCORE: "+score;
            pointb = true;
            pointa = false;
        }
       

        if (other.tag == "enemy") {
            SceneManager.LoadScene(0);
            record = PlayerPrefs.GetInt("Record");
            tryCount++;
            if(score > record)
            {
                SaveRecord();
            }
            SaveGame();
        }
        
    }



    public void change() {
        check =!check;
        //tapAudio.Play();
    }
    void SaveGame()
    {
    PlayerPrefs.SetInt("SavedInteger", score);
    PlayerPrefs.SetInt("tryCount", tryCount);
    PlayerPrefs.Save();
    Debug.Log("Game data saved!");
    }
    void SaveRecord(){
        PlayerPrefs.SetInt("Record", score);
        PlayerPrefs.Save();
    }
    public void tapSound(){
        tapAudio.Play();
    }

}
