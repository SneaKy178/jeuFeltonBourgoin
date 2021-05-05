using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private float movementSpeed = 5f;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform rayStart;

    

    private void Start()
    {
       
    }

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
        if(isOnGround())
        {
            if (Input.GetButtonDown("Jump"))
            {
                animator.SetBool("Jump", true);
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
                
            }else if (animator.GetBool("Jump"))
            {
                animator.SetBool("Jump", false);
            }
        }

    }
    
    private bool isOnGround()
    {
        LayerMask mask = LayerMask.GetMask("Ground");
        
        Debug.DrawLine(rayStart.transform.position, new Vector2(rayStart.transform.position.x, rayStart.transform.position.y) + Vector2.down * 0.5f , Color.blue);
        RaycastHit2D rayCastHit = Physics2D.Raycast(rayStart.transform.position, Vector2.down, .5f, mask);
        return rayCastHit.collider != null;
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
