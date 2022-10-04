using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using GooglePlayGames;
// using GooglePlayGames.BasicApi;
// using UnityEngine.SocialPlatforms;

public class ScoreMenu : MonoBehaviour
{
    private int scr;
    private int rec;
    // public InterAd ad;
    private const string leaderBoard = "CgkI2Jf9pc4NEAIQAQ"; 
    private int tryCount;
    public Text scoreText;
    public Text recordText;
    void Start()
    {
        // PlayGamesPlatform.DebugLogEnabled = true;
        // PlayGamesPlatform.Activate();
        // Social.localUser.Authenticate(success =>
        // {
        //     if(success)
        //     {
        //         Debug.Log("++++++++++++++++ zbs suc");
        //     }
        //     else
        //     {
        //         Debug.Log("---------------- ne zbs suc");
        //     }
        // });

        LoadGame();
        scoreText.GetComponent<Text>().text = ""+scr;
        recordText.GetComponent<Text>().text = ""+rec;

        // Social.ReportScore(rec,leaderBoard,(bool success) => { });


    //    if(tryCount%5==0)
    //    {
    //        ad.ShowAd();
    //    }

    }

    void LoadGame()
    {
        if (PlayerPrefs.HasKey("SavedInteger"))
        {
            scr = PlayerPrefs.GetInt("SavedInteger");
            rec = PlayerPrefs.GetInt("Record");
            tryCount = PlayerPrefs.GetInt("tryCount");
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }
    // public void ShowLeaderBoard()
    // {
    //     Social.ShowLeaderboardUI();
    // }
    // public void ExitFromGPS()
    // {
    //     Application.Quit();
    //     PlayGamesPlatform.Instance.SignOut();
    // }
}
