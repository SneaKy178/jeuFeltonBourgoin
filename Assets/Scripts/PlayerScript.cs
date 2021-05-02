using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private float movementSpeed = 5f;
    private int jumpCount;
    [SerializeField] private int maxJumpCount;
    [SerializeField] private float floorYLevel = -1;
    public bool isGrounded = false;
    private void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * movementSpeed;
    }

    void Jump()
    {
        if (player.transform.position.y < floorYLevel)
             {
                 jumpCount = 0;
             }
        
        if (jumpCount < maxJumpCount)
        {
            if (Input.GetButtonDown("Jump"))
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
                jumpCount++;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        String scenename = currentScene.name;

        if (SceneManager.GetActiveScene().name == "World1")
        {
            if (collision.gameObject.tag == "Pieges")
            {
                SceneManager.LoadScene("World1");
            }
        }
        
        if (SceneManager.GetActiveScene().name == "World2")
        {
            if (collision.gameObject.tag == "Pieges")
            {
                SceneManager.LoadScene("World2");
            }
        }
        
        

        if (collision.gameObject.tag == "Flag")
        {
            SceneManager.LoadScene("World2");
        }
        
    }
}
