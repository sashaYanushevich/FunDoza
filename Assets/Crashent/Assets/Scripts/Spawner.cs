using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform Pos;
    public Transform Pos2;
    public GameObject Enemy;
    public float spawnTime=2.2f;
    public Player plr;
    // Start is called before the first frame update
    void Start()
    {
        plr = FindObjectOfType<Player>();
        if(plr == null)
        {
            Debug.Log("err");
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
        int rand = Random.Range(0, 2);
        if(rand == 1)
            Instantiate(Enemy, Pos.position, Quaternion.identity);
        else
            Instantiate(Enemy, Pos2.position, Quaternion.identity);
        Repeat();
    }
}
