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
    public bool canJump;
    [SerializeField] private int maxJumpCount;
    [SerializeField] private float floorYLevel = -1;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * movementSpeed;

        Flip(movement.x);

        float animatorSpeed = Mathf.Abs(movement.x);
        animator.SetFloat("MovementSpeed",animatorSpeed);
        
    }

    void Jump()
    {
        // if (player.transform.position.y < floorYLevel)
        //      {
        //          jumpCount = 0;
        //          animator.SetBool("Jump", false);
        //          // Debug.Log("should be false");
        //          // Debug.Log(animator.GetBool("Jump"));
        //      }
        
        // if (jumpCount < maxJumpCount)
        if(canJump)
        {
            if (Input.GetButtonDown("Jump"))
            {
                animator.SetBool("Jump", true);
                // Debug.Log("should be true");
                // Debug.Log(animator.GetBool("Jump"));
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
                jumpCount++;
                canJump = false;
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

    void Flip(float _movement)
    {
        if (_movement > 0.1f)
        {
            spriteRenderer.flipX = false;
        } else if (_movement < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}
