using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float JumpForce;
    public float Speed;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
       Horizontal = Input.GetAxisRaw("Horizontal");

        Animator.SetBool("Running", Horizontal != 0.0f);

        Debug.DrawRay(transform.position,Vector3.down*0.1f,Color.red);

        if (Physics2D.Raycast(transform.position,Vector3.down,0.1f))

        {
            Grounded = true;
        }
        else Grounded = false;

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }

    }
    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up*JumpForce);
    }
    private void FixedUpdate()

    {
        Rigidbody2D.velocity = new Vector2 (Horizontal,Rigidbody2D.velocity.y);
    }
}
