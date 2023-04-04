using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public GameObject bulletSpawn;
    public GameObject bullet;

    public GameObject turretPrefab;
    private GameObject liveTurret;


    private float timer = 0;
    public float fireRate = 0.25f;
    public float minX, minY, maxX, maxY;

    void Start()
    {
        
    }

    void Update()
    {
        //Cursor position
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);


        float newX, newY;
        newX = Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, minX, maxX);
        newY = Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, minY, maxY);
        GetComponent<Rigidbody2D>().position = new Vector2(newX, newY);

        float h, v;
        h = UnityEngine.Input.GetAxis("Horizontal");
        v = UnityEngine.Input.GetAxis("Vertical");

        Vector2 newvelocity = new Vector2(h, v);
        GetComponent<Rigidbody2D>().velocity = newvelocity * speed;

        if (Input.GetAxis("Fire1") > 0 && timer > fireRate)
        {
            GameObject gObj;
            gObj = GameObject.Instantiate(bullet, transform.position, transform.rotation);
            gObj.transform.Rotate(new Vector3(0, 0, -90));
            gObj.GetComponent<Rigidbody2D>().velocity = worldPosition - new Vector2(transform.position.x, transform.position.y);
            timer = 0;
        }
        timer += Time.deltaTime;

        if (Input.GetButtonDown("Fire2"))
        {
            if (liveTurret != null)
            {
                Destroy(liveTurret);
            }
            liveTurret = Instantiate(turretPrefab);
            liveTurret.transform.position = worldPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D colloider)
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }

    private void OnTriggerExit2D(Collider2D colloider)
    {

    }
}


