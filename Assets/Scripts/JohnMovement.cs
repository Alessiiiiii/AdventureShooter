using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMovement : MonoBehaviour
{
    public GameObject BulletPrefap;
    
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
        Debug.Log("Horizontal input: " + Horizontal);

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("Running", Horizontal != 0.0f);
        Debug.Log("Running: " + (Horizontal != 0.0f));

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grid = true;
            Debug.Log("John está en el suelo.");
        }
        else
        {
            Grid = false;
            Debug.Log("John no está en el suelo.");
        }

        if (Input.GetKeyDown(KeyCode.W) && Grid)
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Jump()
    {
        Debug.Log("John salta.");
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void Shoot()
    {
        if (BulletPrefap == null)
        {
            Debug.LogError("BulletPrefab es nulo, no se puede instanciar.");
            return;
        }

        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject BulletInstance = Instantiate(BulletPrefap, transform.position+direction*0.1f, Quaternion.identity);

        if (BulletInstance != null)

        {
            BulletInstance.GetComponent<BulletPrefap>().SetDirection(direction);



            Debug.Log("Bala instanciada correctamente con dirección y velocidad.");

        }
        
        else
        {       
                 
              
       
        
            Debug.LogError("BulletInstance es nulo después de instanciar.");
        }
    }

    private void FixedUpdate()
    {
        Debug.Log("Velocidad de John: " + Rigidbody2D.velocity);
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }

    public void Hit()
    {
        Health=Health -= 1;
        if (Health == 0) Destroy(gameObject);
    }
}
