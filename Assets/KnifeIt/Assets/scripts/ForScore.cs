using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForScore : MonoBehaviour
{
    public Text textScore;
    public int scorre;

    void Update()
    {
        scorre=DestroyByHit.score;
        textScore.GetComponent<Text>().text="Score: "+scorre;
    }


}
