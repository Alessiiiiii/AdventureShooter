using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public GameObject John;
    private float LastShoot;

private void Update()
{
        Vector3 direction = John.transform.position- transform.position;
        if(direction.x >=0.0f) transform.localScale=new Vector3(1.0f,1.0f,1.0f);
        else transform.localScale=new Vector3(-1.0f,1.0f,1.0f);

        float distance =Mathf.Abs( John.transform.position.x - transform.position.x);
        
        if (distance <1.0f &&Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
        
    }
    private void Shoot()
    {
        Debug.Log("Shoot");
    }
}