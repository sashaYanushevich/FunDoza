using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxJump : MonoBehaviour
{

    public Rigidbody2D a;
    private bool isForced=false;
    private bool isTouched;

    public bool onGround;
    public Transform GroundCheck;
    public float checkRadius=0.5f;
    public LayerMask Ground;
    public Text htj;
    public static bool ft;
    public static bool tempflag;
    public System.DateTime dtfirst;


    void Start()
    {
        ft=false;
        tempflag=false;
        isTouched=false;
        isForced=false;
        a=GetComponent<Rigidbody2D>();   
    }

    public void FixedUpdate()
    {
        if(ft && !tempflag){
            tempflag=true;
            htj.GetComponent<Text>().color=new Color(255,0,0);
            htj.GetComponent<Text>().text="Score: 0";
        }
        if(onGround) {
            isForced=false;
            isTouched=false;
        }
        else{
            isForced=true;
            isTouched=true;
        }
        CheckGround();
    }

    public void CheckGround(){
        onGround=Physics2D.OverlapCircle(GroundCheck.position,checkRadius,Ground);
    }


    public void CheckTimeNow(){
        dtfirst=System.DateTime.Now;
    }

    public void Throw () {
        if(!isForced) {
            if(!ft)ft=true;
            System.TimeSpan res=System.DateTime.Now-dtfirst;
            System.DateTime rel = new System.DateTime(res.Ticks);
            int millsecond = rel.Millisecond;
            var go=GameObject.FindGameObjectWithTag("hero");
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(millsecond/10,570));
            isForced=true;
        }
    }

    public void Touch(){
        isTouched=true;
    }
}
