using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path;
using UnityEngine;

public class EnemiScript : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Transform[] waypoints;
    
    private Transform target;
    private int pointDestination = 0;

    [SerializeField] private SpriteRenderer serpent;
    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * (movementSpeed * Time.deltaTime), Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            
            pointDestination = (pointDestination + 1) % waypoints.Length;
            target = waypoints[pointDestination];
            serpent.flipX = !serpent.flipX;
        }
        
    }
}
