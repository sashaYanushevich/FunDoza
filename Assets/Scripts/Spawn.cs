using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform Pos;
    public Transform Pos2;
    public GameObject Cactus;
    public GameObject Bird;
    public GameObject Cactus2;
    public float spawnTime=2.2f;
    public DeleteEnemy scr;
    // Start is called before the first frame update
    void Start()
    {
        scr = FindObjectOfType<DeleteEnemy>();
        if(scr == null)
        {
            Debug.Log("ERROR PLR");
        }
        StartCoroutine(SpawnerCD());
    }

    void Repeat()
    {
        StartCoroutine(SpawnerCD());
    }

    IEnumerator SpawnerCD()
    {
        // if(Player.score >=10 && Player.score <20)
        //     spawnTime =1.6f;
        // if(Player.score >=20 && Player.score <30)
        //     spawnTime =1.2f;
        // if(Player.score >=30 && Player.score <40)
        //     spawnTime =1f;
        // if(Player.score >=40 && Player.score <50)
        //     spawnTime =0.8f;
        yield return new WaitForSeconds(spawnTime);
        int rand = Random.Range(0, 10);
        Debug.Log(rand);
        if(rand <=8)
        {
            if(scr.score<=10)
                Instantiate(Cactus, Pos.position, Quaternion.identity);
            if(scr.score >10)
            {
                int rand2 = Random.Range(0, 3);
                if(rand2 <=1)
                    Instantiate(Cactus2, Pos.position, Quaternion.identity);
                else
                    Instantiate(Cactus, Pos.position, Quaternion.identity);

            }
        }
        else
            Instantiate(Bird, Pos2.position, Quaternion.Euler (0,180,0));
        Repeat();
    }
}
