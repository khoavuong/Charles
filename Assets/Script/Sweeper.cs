using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweeper : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject[] buffs;
        buffs = GameObject.FindGameObjectsWithTag("buff");
        foreach (GameObject buff in buffs)
            Physics2D.IgnoreCollision(buff.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        GameObject mainObj = GameObject.Find("mainObj");
        Physics2D.IgnoreCollision(mainObj.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        GameObject[] bullets;
        bullets = GameObject.FindGameObjectsWithTag("bullet");
        foreach (GameObject bullet in bullets)
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        GetComponent<Rigidbody2D>().velocity = 5 * new Vector2(1, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "border_right")
            Destroy(gameObject);
        else if (collision.gameObject.name == "border_bot") { }
        else if (collision.gameObject.name == "border_top") { }
        else Destroy(collision.gameObject);
    }
}
