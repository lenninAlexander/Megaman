using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala3 : MonoBehaviour
{
    private Rigidbody2D rbd;
    public float speed;
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rbd.velocity = new Vector2(+speed, 0);
    }
}
