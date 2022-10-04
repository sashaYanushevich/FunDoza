using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject scroll;
    public GameObject settingsBut;
    public GameObject settings;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SettingsButClick()
    {
        scroll.SetActive(false);
        settingsBut.SetActive(false);
        settings.SetActive(true);
    }
    public void OkButClick()
    {
        scroll.SetActive(true);
        settingsBut.SetActive(true);
        settings.SetActive(false);
    }
    public void DinoButClick() 
    {
        SceneManager.LoadScene(1);
    }
    public void AvoidOrDieButClick()
    {
        SceneManager.LoadScene(2);
    }
    public void JumperButClick()
    {
        SceneManager.LoadScene(3);
    }
    public void KnifeButClick()
    {
        SceneManager.LoadScene(4);
    }
    public void BirdButClick() {
        SceneManager.LoadScene(5);
    }
    public void BallButClick()
    {
        SceneManager.LoadScene(6);
    }
    public void CrashentButClick() 
    {
        SceneManager.LoadScene(7);
    }
}
