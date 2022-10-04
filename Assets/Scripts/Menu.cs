using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject panel;
    //public Animation anim; 
    private void Start() {
      // anim = GetComponent<Animation>();
      panel.SetActive(false);
    }
    void Update () {

        if(Input.GetKeyDown (KeyCode.E)){
          Debug.Log("+");
          panel.SetActive(true);
        }
    }
}
