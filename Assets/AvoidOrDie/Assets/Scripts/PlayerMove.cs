using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{

    public float Speed;

    public int Score;

    public bool isMove;
    public bool isGame = false;

    public AudioClip CoinSound;
    public AudioClip MoveSound;
    public AudioClip EnemySound;

    public GameObject Particle;
    public GameObject Player;
    public GameObject NextText;
    public GameObject ScoreTextObj;
    public GameObject GameOverPan;
    public GameObject PanGame;
    public GameObject RecordText;

    public Text ScoreText;
    public Text ScoreTextGO;

    private Save sv = new Save();

    private void FixedUpdate()
    {
        if (isGame == true)
        {
            if (isMove == true)
            {
                transform.Rotate(0, 0, Speed);
            }

            if (isMove == false)
            {
                transform.Rotate(0, 0, -Speed);
            }
        }
    }

    private void Awake()
    {
        if(PlayerPrefs.HasKey("SV"))
        {
            sv = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("SV"));
            Score = sv.score;
        }
    }

    private void OnApplicationQuit()
    {
        if (Score > sv.score)
        {
            sv.score = Score;
            PlayerPrefs.SetString("SV", JsonUtility.ToJson(sv));
        }
    }

    private void Update()
    {
        ScoreText.text = Score.ToString();
        ScoreTextGO.text = Score.ToString();

        if(Score > sv.score)
        {
            RecordText.SetActive(true);
        }
    }

    public void OnClickPan()
    {
        isMove = !isMove;
        GetComponent<AudioSource>().PlayOneShot(MoveSound);

    }

    public void OnClickGame()
    {
        ScoreTextObj.SetActive(true);
        NextText.SetActive(false);
        isGame = true;
        Score = 0;
        PanGame.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isGame == true)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                GetComponent<AudioSource>().PlayOneShot(EnemySound);
                Particle.SetActive(true);
                Player.SetActive(false);
                GameOverPan.SetActive(true);
                isGame = false;
            }

            if (collision.gameObject.tag == "Coin")
            {
                Score++;
                GetComponent<AudioSource>().PlayOneShot(CoinSound);
            }
        }
    }

    public void RestartGame()
    {
        if (Score > sv.score)
        {
            sv.score = Score;
            PlayerPrefs.SetString("SV", JsonUtility.ToJson(sv));
        }
        SceneManager.LoadScene(2);
    }
    public void ExitToMain()
    {
        SceneManager.LoadScene(0);
    }
}

[Serializable]
public class Save
{
    public int score;
}
