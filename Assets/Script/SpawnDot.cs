using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDot : MonoBehaviour {
    // Dot Prefab
    public GameObject[] groups;

    // Borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", 1, 0.3f);
    }

    void Spawn()
    {
        // x position between left & right border
        float x = Random.Range(borderLeft.position.x,
                                  borderRight.position.x);

        // y position between top & bottom border
        float y = Random.Range(borderBottom.position.y,
                                  borderTop.position.y);

        int i = Random.Range(0, groups.Length);
        // Instantiate the food at (x, y)
        Instantiate(groups[i],
                    new Vector2(x, y),
                    Quaternion.identity); // default rotation
    }
}
