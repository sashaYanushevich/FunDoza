using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ForPanelFunctions : MonoBehaviour
{
    Vector3 startposfloor;
    Vector3 startposhero;
    public GameObject floor;
    public GameObject hero;
    public GameObject panel;
    public GameObject otherui;
    public Text scr;
    public GameObject destr1;
    public GameObject destr2;
    public GameObject destr3;
    public GameObject destr4;

    private void Start()
    {
        startposfloor=GameObject.FindGameObjectWithTag("Floor").transform.position;
        startposhero=GameObject.FindGameObjectWithTag("hero").transform.position;
    }

    public void RestartGameFunc(){
        Debug.Log("Активировалась функция");
        destr1.SetActive(true);
        destr2.SetActive(true);
        destr3.SetActive(true);
        destr4.SetActive(true);
        GameProcess.score=0;
        scr.GetComponent<Text>().text="hold to jump";
        scr.GetComponent<Text>().color=new Color(255,255,255);
        BoxJump.tempflag=false;
        BoxJump.ft=false;
        panel.SetActive(false);
        otherui.SetActive(true);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
}
