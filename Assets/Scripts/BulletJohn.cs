using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletJohn : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    public float speed;
    void Start()
    {
       Rigidbody2D = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D.velocity = Vector2.right*speed;
    }
}
