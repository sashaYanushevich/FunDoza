using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MvEnemy : MonoBehaviour
{
    public float speed;
    public Vector2 dir;
    public DeleteEnemy scr;
    // public Player plr;
    void Start(){
        scr = FindObjectOfType<DeleteEnemy>();
        if(scr == null)
        {
            Debug.Log("ERROR PLR");
        }
    }
    private void FixedUpdate() {
        // Debug.Log("Score: " + scr.score + "Speed: " + speed );
        if(scr.score <10)
            speed=1.9f;

        if(scr.score >=10 && scr.score <20)
        {
            speed=1.9f;
        }
        if(scr.score >=20 && scr.score <30)
        {
            speed=2.2f;
        }
        if(scr.score >=30 && scr.score <40)
            speed=2.6f;
        if(scr.score >=40 && scr.score <60)
            speed=3f;
        if(scr.score >=60 && scr.score <85)
            speed=3.4f;
        if(scr.score >=85 && scr.score <100)
            speed=3.7f;
        transform.Translate(speed*dir*Time.deltaTime,Space.World);
        
    }

}
