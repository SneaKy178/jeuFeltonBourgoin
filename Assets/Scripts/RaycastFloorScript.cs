using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastFloorScript : MonoBehaviour
{
    
    private RaycastHit2D hit;
    [SerializeField] private float distance;

    [SerializeField] private PlayerScript _playerScript;
    // Update is called once per frame
    void Update()
    {

    
    
       
        // if (Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right)))
        // {
        //     
        //     Debug.DrawRay(transform.position, Vector2.right * hit.distance, Color.red);
        //     print("hit");
        // }

        // Vector2 vector2 = new Vector2(1, 0) * distance;
        // hit = Physics2D.Raycast(transform.position, Vector2.right, 1f);
        // Vector2 debugRayEnd = new Vector2(transform.position.x, transform.position.y) + Vector2.right * 1;
        // Debug.DrawLine(transform.position, debugRayEnd , Color.red);
        //
        // if (hit.collider.gameObject.tag == "Player")
        // {
        //     _playerScript.canJump = true;
        //     Debug.Log("hit player");
        // }
    }
}

