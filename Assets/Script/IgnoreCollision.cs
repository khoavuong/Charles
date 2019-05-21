using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject[] dots;
        dots = GameObject.FindGameObjectsWithTag("dot");
        foreach (GameObject dot in dots)
            Physics2D.IgnoreCollision(dot.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        GameObject[] bullets;
        bullets = GameObject.FindGameObjectsWithTag("bullet");
        foreach (GameObject bullet in bullets)
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
