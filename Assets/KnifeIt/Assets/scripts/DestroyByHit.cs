using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByHit : MonoBehaviour
{
    public GameObject knife;
    public static int score = 0;

    private void OnTriggerEnter2D(Collider2D other) {
       if (other.tag=="knife") {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate (knife,new Vector3(0f,-3.6f,0f),Quaternion.identity);
            score++;
            
        }
    }
}
