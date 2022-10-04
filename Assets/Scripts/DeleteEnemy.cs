using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DeleteEnemy : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public Text scoreTextMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<Text>().text = "SCORE: "+score;
        scoreTextMenu.GetComponent<Text>().text = "SCORE: "+score;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy") 
        {
            score++;
            Destroy(other.gameObject);
        }
    }
}
