using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMovement : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float JumpForce;
    public float Speed;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grid;
    private float LastShoot;
    private int Health = 5;


    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
       Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f)transform.localScale= new Vector3 (-1.0f,1.0f,1.0f);
        else if (Horizontal > 0.0f)transform.localScale = new Vector3(1.0f,1.0f,1.0f);

        Animator.SetBool("Running", Horizontal != 0.0f);

        Debug.DrawRay(transform.position,Vector3.down*0.1f,Color.red);

        if (Physics2D.Raycast(transform.position,Vector3.down,0.1f))

        {
            Grid = true;
        }
        else Grid = false;

        if (Input.GetKeyDown(KeyCode.W) && Grid)
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.Space)&&Time.time>LastShoot+0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }
    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up*JumpForce);
    }
    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction=Vector3.left;

       GameObject bullet= Instantiate(BulletPrefab, transform.position+direction*0.1f, Quaternion.identity);
        bullet.GetComponent<BulletJohn>().SetDirection(direction);
    }

    private void FixedUpdate()

    {
        Rigidbody2D.velocity = new Vector2 (Horizontal,Rigidbody2D.velocity.y);
    }
    public void Hit()
    {
        Health = Health - 1;
        if (Health == 0) Destroy(gameObject);
    }
}
