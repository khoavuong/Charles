using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDot : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
        GameObject[] buffs;
        buffs = GameObject.FindGameObjectsWithTag("buff");
        foreach (GameObject buff in buffs)
            Physics2D.IgnoreCollision(buff.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        GameObject[] dots;
        dots = GameObject.FindGameObjectsWithTag("dot");
        foreach (GameObject dot in dots)
            Physics2D.IgnoreCollision(dot.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
	
	// Update is called once per frame
	void Update () {
        GameObject obj;
        obj = GameObject.Find("mainObj");
        float a = obj.transform.position.x - transform.position.x;
        float b = obj.transform.position.y - transform.position.y;
        GetComponent<Rigidbody2D>().velocity = new Vector2(a, b).normalized * speed;
    }

    
}
