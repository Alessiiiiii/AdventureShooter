using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public GameObject John;
    private float LastShoot;
    public GameObject BulletPrefab;
    private int Health = 3;


        

        private void Update()

        {
            if (John == null) return;

            Vector3 direction = John.transform.position - transform.position;
            if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

            float distance = Mathf.Abs(John.transform.position.x - transform.position.x);

            if (distance < 1.0f && Time.time > LastShoot + 0.25f)
            {
                Shoot();
                LastShoot = Time.time;
            }
        }

        private void Shoot()
        {
            if (BulletPrefab == null)
            {
                Debug.LogError("BulletPrefap es nulo, no se puede instanciar.");
                return;
            }

            Vector3 direction;
            if (transform.localScale.x == 1.0f) direction = Vector3.right;
            else direction = Vector3.left;

            GameObject BulletPrefap = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
            if (BulletPrefap != null)
            {
                BulletPrefap.GetComponent<BulletPrefap>().SetDirection(direction);
            }
            else
            {
                Debug.LogError("BulletJohn es nulo después de instanciar.");
            }
        }

        public void Hit()
        {
            Health -= 1;
            if (Health == 0) Destroy(gameObject);
        }
    }
