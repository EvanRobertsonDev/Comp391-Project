using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{

    public GameObject enemySpawner;
    public GameObject player;
    public GameObject turret;

    public TMP_Text health;
    public TMP_Text round;
    public TMP_Text turretHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turret = GameObject.FindGameObjectWithTag("Turret");

        health.text = "Health: " + player.GetComponent<PlayerController>().health.ToString();
        round.text = "Round: " + (enemySpawner.GetComponent<EnemySpawnScript>().roundNumber + 1).ToString();
        if (turret == null)
        {
            turretHealth.text = "Turret Health: n/A";
        }
        else
        {
            turretHealth.text = "Turret Health: " + turret.GetComponent<TurretScript>().health.ToString();
        }

        if (enemySpawner.GetComponent<EnemySpawnScript>().roundNumber == 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (player.GetComponent<PlayerController>().health < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
