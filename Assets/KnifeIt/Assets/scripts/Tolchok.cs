using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tolchok : MonoBehaviour
{
    public Rigidbody2D a;
    private bool isForced=false;
    static private bool isTouched;

    void Start()
    {
        isTouched=false;
        isForced=false;
        a=GetComponent<Rigidbody2D>();   
    }

    public void FixedUpdate()
    {
        if(isTouched) {
            Throw();
            isTouched=false;
        }
    }

    public void Throw () {
        if(!isForced) {
            a.AddForce(new Vector2(0,1200));
            isForced=true;
        }
    }

    public void Touch(){
        isTouched=true;
    }
}
