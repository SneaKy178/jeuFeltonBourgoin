using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float movementSpeed = 5f;
    public bool isGrounded = false;
    private void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * movementSpeed;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true) 
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
        
    }
    

}
