using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletJohn : MonoBehaviour
{
    public AudioClip Sound;
    private Rigidbody2D Rigidbody2D;
    public float Speed;
    private Vector2 Direction;
    void Start()
    {
       Rigidbody2D = GetComponent<Rigidbody2D>(); 
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction*Speed;
    }
    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }
    public void DestoyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        JohnMovement John = collision.GetComponent<JohnMovement>();
        GruntScript Grunt = collision.GetComponent<GruntScript>();
        if (John != null)
        {
            John.Hit();
        }
        if (Grunt != null)
        {
            Grunt.Hit();
        }
        DestoyBullet();
    }
    
}

