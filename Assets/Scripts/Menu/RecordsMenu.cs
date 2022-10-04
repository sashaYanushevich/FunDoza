using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordsMenu : MonoBehaviour
{
    public Text recordCrashent;
    public Text recordAvoid;
    public Text recordJumper;
    public Text recordKnifeIt;
    public Text recordBall;



    private Save sv = new Save();
    // Start is called before the first frame update
    void Start()
    {
        int record = PlayerPrefs.GetInt("Record");
        recordCrashent.GetComponent<Text>().text = "Record: " + record;
        sv = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("SV"));
        recordAvoid.GetComponent<Text>().text = "Record: " + sv.score;
        recordJumper.GetComponent<Text>().text = "Record: " + PlayerPrefs.GetInt("LocalRecordJumper");
        recordKnifeIt.GetComponent<Text>().text = "Record: " + PlayerPrefs.GetInt("LocalRecordKnife");
        recordBall.GetComponent<Text>().text = "Record: " + PlayerPrefs.GetInt("score");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
