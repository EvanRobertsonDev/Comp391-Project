using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public GameObject bullet;

    private float timer = 0;
    private float attackTimer = 0;
    public float fireRate = 0.25f;
    public float speed = 4f;

    public float health = 10f;

    GameObject target;
    List<GameObject> enemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Count == 0) {
            enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        }
        else
        {
            foreach (GameObject enemy in enemies)
            {
                if (timer > fireRate && enemy != null)
                {
                    GameObject gObj;
                    gObj = GameObject.Instantiate(bullet, new Vector2(transform.position.x, transform.position.y - 0.5f), transform.rotation);
                    gObj.transform.Rotate(new Vector3(0, 0, -90));
                    gObj.GetComponent<Rigidbody2D>().velocity = enemy.transform.position - transform.position;
                    timer = 0;
                }
            }
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        timer += Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (attackTimer > 2)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                health -= 2;
            }
            attackTimer = 0;
        }
        attackTimer += Time.deltaTime;
    }
}
