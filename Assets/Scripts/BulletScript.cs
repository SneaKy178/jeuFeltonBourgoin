using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
     private float speed = 20;
        [SerializeField] private Rigidbody2D rb;
        void Start()
        {
            if (gameObject.name == "Canon6")
            {
    
                rb.velocity = transform.right * speed;
            }
            else
            {
                rb.velocity = transform.up * speed;
            }
            
           
        }
    
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Decor")
            {
                Destroy(this.gameObject);
            }
        }
}
