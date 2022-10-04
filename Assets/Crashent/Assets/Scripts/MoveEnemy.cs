using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float speed;
    public Vector2 dir;
    public Player plr;
    void Start(){
        plr = FindObjectOfType<Player>();
        if(plr == null)
        {
            Debug.Log("wlf;lf");
        }
    }
    private void FixedUpdate() {
        //Debug.Log("Score: " + Player.score + "Speed: " + speed );
        if(Player.score >=10 && Player.score <20)
            speed=0.4f;
        if(Player.score >=20 && Player.score <30)
            speed=0.5f;
        if(Player.score >=30 && Player.score <40)
            speed=0.6f;
        if(Player.score >=40 && Player.score <50)
            speed=0.8f;
        transform.Translate(speed*dir*Time.deltaTime,Space.World);
        transform.rotation *= Quaternion.Euler(0f,0f,2f);
    }
}
