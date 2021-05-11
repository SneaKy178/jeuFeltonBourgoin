using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingTrapObject : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private Transform rayCast;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayCast.transform.position, Vector2.down * 150f);

        if (hit.collider.gameObject.CompareTag("Player"))
        {
            rb.isKinematic = false;
            rb.AddForce(new Vector2(0,(-30000 * Time.deltaTime)));
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
