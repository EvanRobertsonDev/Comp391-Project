using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 5f;
    public int health = 30;
    GameObject target;

    private void Update()
    {
        target = GameObject.FindGameObjectWithTag("Turret");
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player");
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, (speed * Time.deltaTime));
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            health -= 5;
            Destroy(collision.gameObject);
        }
    }
}
