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
    private int maxJumps = 1;
    private int jumpCounter = 0;
    [SerializeField] private Sprite kingSprite;
    [SerializeField] private Sprite astronautSprite;
    [SerializeField] private Sprite warriorSprite;

    

    private void Start()
    {
        // initializePlayer(GameManager.Instance.getCurrentPlayerModel());
        // spriteRenderer.sprite = GameManager.Instance.getCurrentPlayerModel();
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
        if (isOnGround())
        {
            jumpCounter = 0;
            if (animator.GetBool("Jump"))
            {
                animator.SetBool("Jump", false);
            }
        }
        if(Input.GetButtonDown("Jump"))
        {
            if (jumpCounter < maxJumps)
            {
                // animator.SetBool("Jump", true);
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
                jumpCounter++;
            }
        }

    }
    
    private bool isOnGround()
    {
        LayerMask mask = LayerMask.GetMask("Ground");
        
        Debug.DrawLine(rayStart.transform.position, new Vector2(rayStart.transform.position.x, rayStart.transform.position.y) + Vector2.down * 0.5f , Color.blue);
        RaycastHit2D rayCastHit = Physics2D.Raycast(rayStart.transform.position, Vector2.down, .01f, mask);
        return rayCastHit.collider != null;
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        String scenename = currentScene.name;

        if (SceneManager.GetActiveScene().name == "World_1")
        {
            if (collision.gameObject.tag == "Pieges")
            {
               
                SceneManager.LoadScene("World_1");
            }
        }
        
        if (SceneManager.GetActiveScene().name == "World_2")
        {
            if (collision.gameObject.tag == "Pieges")
            {
                SceneManager.LoadScene("World_2");
            }
        }
        
        

        if (collision.gameObject.tag == "Flag")
        {
            SceneManager.LoadScene("World_2");
        }

        if (collision.gameObject.name == "Door")
        {
            SceneManager.LoadScene("CreditScene");
        }
    }

    void Flip(float _movement)
    {

        if (gameObject.name == "Player1" || gameObject.name == "Player3" )
        {
            if (_movement > 0.1f)
            {
                spriteRenderer.flipX = false;
            } else if (_movement < -0.1f)
            {
                spriteRenderer.flipX = true;
            }
        }

        if (gameObject.name == "Player2")
        {
            if (_movement > 0.1f)
            {
                spriteRenderer.flipX = true;
            } else if (_movement < -0.1f)
            {
                spriteRenderer.flipX = false;
            }
        }
    }


    // private void initializePlayer(GameManager.CharacterSelected characterSelected)
    // {
    //     if (characterSelected == GameManager.CharacterSelected.KING)
    //     {
    //         spriteRenderer.sprite = kingSprite;
    //         // spriteRenderer.size = new Vector2(1, 1);
    //         Debug.Log("King selected");
    //         transform.localScale = new Vector2(1, 1);
    //     }
    //     if (characterSelected == GameManager.CharacterSelected.ASTRONAUT)
    //     {
    //         spriteRenderer.sprite = astronautSprite;
    //         // spriteRenderer.size = new Vector2(1, 1);
    //         Debug.Log("Astronaut selected");
    //         transform.localScale = new Vector2(1, 1);
    //     }
    //     if (characterSelected == GameManager.CharacterSelected.WARRIOR)
    //     {
    //         spriteRenderer.sprite = warriorSprite;
    //         // spriteRenderer.size = new Vector2(0.01f, 0.01f);
    //         Debug.Log("Warrior selected");
    //
    //     }
    //     
    // }
    
}
