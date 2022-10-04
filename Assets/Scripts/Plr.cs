using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Plr : MonoBehaviour
{
    public float jumpVelocity;
    private bool isJump = false;
    public GameObject Spawner;
    public GameObject MoveEnemy;
    public GameObject panel;
    public GameObject textScore;
    public GameObject playBtn;
    public GameObject tapToStart;
    public GameObject pauseBtn;
    public DeleteEnemy scr;
    public GameObject pause;
    public GameObject enemy;
    public Text textRecord;
    private int score;
    private bool isPause = false;
    private string gameID = "4461317";

    Rigidbody2D rb;

    private void Start()
    {

    }

    private void Awake()
    {
        Debug.Log("Start");

        rb = GetComponent<Rigidbody2D>();
        enemy.SetActive(true);
        Spawner.SetActive(true);
        panel.SetActive(false);
        MoveEnemy.SetActive(true);
        Time.timeScale = 0f;

    }                                  
    private void Update()
	{
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "platform") 
        {
            isJump = false;
        }

        if (other.tag == "enemy") 
        {
            MoveEnemy.SetActive(false);
            panel.SetActive(true);
            textScore.SetActive(false);
            enemy.SetActive(false);
            Destroy(other.gameObject);
            SaveRecord();
            int record = PlayerPrefs.GetInt("Record");
            textRecord.GetComponent<Text>().text = "RECORD: "+record;
            StartCoroutine(DoSomething());            
            //Destroy(other.gameObject);
        }
    }

    private IEnumerator DoSomething()
    {
        yield return new WaitForSeconds(0.9f);
        Time.timeScale = 0f;
    }

    public void Jump()
    {
        if(!isJump)
        {
            rb.AddForce(new Vector2(0, jumpVelocity));	
            isJump = true;
        }

    }
    public void Pause() {
        if(!isPause)
        {
            Time.timeScale = 0f;
            textScore.SetActive(false);
            pause.SetActive(true);
            isPause= true;
        }
        else
        {
            textScore.SetActive(true);
            pause.SetActive(false);
            Time.timeScale = 1f;
            isPause=false;
        }

    }

    public void RestartGame()
    {
        panel.SetActive(false);
        Spawner.SetActive(true);
        MoveEnemy.SetActive(true);
        textScore.SetActive(true);
        enemy.SetActive(true);
        Time.timeScale = 1f;
        scr.score = 0;

    }
    public void StartGame(){

        textScore.SetActive(true);
        pauseBtn.SetActive(true);
        playBtn.SetActive(false);
        tapToStart.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SaveRecord()
    {
        int record = PlayerPrefs.GetInt("Record");
        if(record<scr.score)
            PlayerPrefs.SetInt("Record", scr.score);
        PlayerPrefs.Save();
    }
    public void ExitGame()
    {
        SceneManager.LoadScene(0);

    }

}