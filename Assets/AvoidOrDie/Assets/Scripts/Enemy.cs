using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject[] prefabs;

    private int i = 1;
     
    public PlayerMove PM;

    private void Update()
    {
        if (PM.isGame == true)
        {
            if (i == 1)
            {
                StartCoroutine(SpawnEnemy());
                i++;
            }
        }
    }

    private void Repeat()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1.5f);
        var clonePrefabs =  Instantiate(prefabs[Random.Range(0, 2)], new Vector2(-8, Random.Range(-1.2f, 1.2f)), Quaternion.identity);
        Repeat();
        yield return new WaitForSeconds(5f);
        Destroy(clonePrefabs);
    }

}
