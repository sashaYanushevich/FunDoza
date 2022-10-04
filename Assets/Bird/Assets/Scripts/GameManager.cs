using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;

   private void Start()
    {
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        GameObject.Find("Canvas2/Score").GetComponent<Text>().text = "SCORE: "+Score.score.ToString();
        Time.timeScale = 0;
    }
    public void Replay()
    {
        SceneManager.LoadScene(5);
    }
    public void ExitToMain()
    {
        SceneManager.LoadScene(0);
    }
}
