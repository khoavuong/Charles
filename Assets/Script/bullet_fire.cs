using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_fire : MonoBehaviour {

    // Use this for initialization
    void Start () {
        GameObject mainObj = GameObject.Find("mainObj");
        Physics2D.IgnoreCollision(mainObj.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        GameObject[] buffs;
        buffs = GameObject.FindGameObjectsWithTag("buff");
        foreach (GameObject buff in buffs)
            Physics2D.IgnoreCollision(buff.GetComponent<Collider2D>(), GetComponent<Collider2D>());
       
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 bulletVec = new Vector2(h, v);
        if (h == 0 && v == 0)
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,1) * 5;
        else GetComponent<Rigidbody2D>().velocity = bulletVec * 5;
    }
	
	void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "border_right"
            || collision.gameObject.name == "border_left"
            || collision.gameObject.name == "border_top"
            || collision.gameObject.name == "border_bot")
            Destroy(gameObject);
        else if (collision.gameObject.tag == "bullet") { }
        else
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
