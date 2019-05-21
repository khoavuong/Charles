using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour {

    public float speed = 25;
    public Sprite[] form;
    public int type = 0;
    public GameObject sweep;
    public GameObject bullet;
    int i=-1000;

    // Use this for initialization
    void Start () {
        InvokeRepeating("buffTimer", 1, 1);
    }
	
	// Update is called once per frame
	void Update () {
        if (i == 5)
        {
            GetComponent<SpriteRenderer>().sprite = form[0];
            transform.localScale = new Vector3(1, 1, 1);
            GetComponent<BoxCollider2D>().size = new Vector3(0.1f, 0.1f, 0.1f);
            type = 0;
        }

        if (type == 2)
        {
            InvokeRepeating("spawn_bullet", 0.1f, 1000);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0) * speed;
            return;
        }

        // Get Horizontal Input
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // Set Velocity (movement direction * speed)
        Vector2 racketVec = new Vector2(h, v);
        GetComponent<Rigidbody2D>().velocity = racketVec * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "saw(Clone)")
        {
            Destroy(collision.gameObject);
            GetComponent<SpriteRenderer>().sprite = form[1];
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            GetComponent<BoxCollider2D>().size = new Vector3(2.25f, 2.25f, 2.25f);
            type = 1;
            i = 0;
        }

        if (type == 1)
        {
            if (collision.gameObject.name != "border_top" &&
            collision.gameObject.name != "border_bot" &&
            collision.gameObject.name != "border_right" &&
            collision.gameObject.name != "border_left")
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name == "sweep(Clone)")
        {
            Destroy(collision.gameObject);
            Instantiate(sweep, new Vector2(-3.31f, -0.08f), Quaternion.identity);
        }

        if (collision.gameObject.name == "gun(Clone)")
        {
            Destroy(collision.gameObject);
            type = 2;
            i = 0;
        }

        if (collision.gameObject.tag == "dot" && type == 0)
            Time.timeScale = 0;
    }

    void buffTimer()
    {
        i++;
    }

    void spawn_bullet()
    {
        Instantiate(bullet, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    }
}
