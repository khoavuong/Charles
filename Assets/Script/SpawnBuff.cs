using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuff : MonoBehaviour {

    // Buff Prefab
    public GameObject[] groups;

    // Borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", 5, 10);
    }

    void Spawn()
    {
        // x position between left & right border
        float x = Random.Range(borderLeft.position.x + 1,
                                  borderRight.position.x - 1);

        // y position between top & bottom border
        float y = Random.Range(borderBottom.position.y + 1,
                                  borderTop.position.y - 1);

        int i = Random.Range(0, groups.Length);
        // Instantiate the food at (x, y)
        Instantiate(groups[i],
                    new Vector2(x, y),
                    Quaternion.identity); // default rotation
    }
}
