using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject[] spawnpoints;
    public GameObject enemy;
    private float timer;

    public int roundNumber;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject spawnpoint in spawnpoints)
        {
            Instantiate(enemy, spawnpoint.transform.position, spawnpoint.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (roundNumber < 10)
        {
            timer += Time.deltaTime;
            if (timer > 25f)
            {
                foreach (GameObject spawnpoint in spawnpoints)
                {
                    Instantiate(enemy, spawnpoint.transform.position, spawnpoint.transform.rotation);
                }
                timer = 0;
                roundNumber++;
            }
        }
    }
}
