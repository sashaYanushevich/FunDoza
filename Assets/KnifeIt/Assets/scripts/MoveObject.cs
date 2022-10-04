using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed;
    public Vector2 dir;

    private void FixedUpdate()
    {
        transform.Translate(speed*dir*Time.deltaTime,Space.World);
        if(DestroyByHit.score>=0 & DestroyByHit.score<6){
            speed=0.5f;
        }
        if(DestroyByHit.score>=6 & DestroyByHit.score<10){
            speed=0.8f;
        }
        if(DestroyByHit.score>=10 & DestroyByHit.score<20){
            speed=1f;
        }
        if(DestroyByHit.score>=20 & DestroyByHit.score<30){
            speed=1.3f;
        }
        if(DestroyByHit.score>=20 & DestroyByHit.score<30){
            speed=1.5f;
        }
        if(DestroyByHit.score>=30 & DestroyByHit.score<45){
            speed=2f;
        }
        if(DestroyByHit.score>=45 & DestroyByHit.score<60){
            speed=2.3f;
        }
        if(DestroyByHit.score>=60 & DestroyByHit.score<80){
            speed=2.6f;
        }
        if(DestroyByHit.score>=80 & DestroyByHit.score<100){
            speed=3f;
        }
        if(DestroyByHit.score>=100){
            speed=3.5f;
        }
    }
}