using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    // [SerializeField] private GameObject kingTransform;
    // [SerializeField] private GameObject astronautTransform;
    
    
    
    
    public Transform target; 
    Vector3 offSet;
    private float smoothFactor;
    // private bool successfullyGrabPlayer;

    private void Start()
    {
        initializePlayerCamera(GameManager.Instance.getCurrentPlayerModel());
    }

    private void Update()
    {

        // if (!successfullyGrabPlayer)
        // {
        //     target = GameObject.Find("Player2(Clone)").transform;
        //     if (target != null)
        //     {
        //         successfullyGrabPlayer = true;
        //     }
        // }
    }

    public void FixedUpdate()
    {
        offSet = new Vector3(0, 0, -10);
        smoothFactor = 30;
        Vector3 targetPosition = target.position + offSet;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.deltaTime);
        transform.position = target.transform.position + offSet;
    }

    private void initializePlayerCamera(GameManager.CharacterSelected characterSelected)
    {
        if (characterSelected == GameManager.CharacterSelected.KING)
        {
            target = GameObject.Find("Player1(Clone)").transform;
            Debug.Log(target);
            Debug.Log("Camera on king");
        }
        if (characterSelected == GameManager.CharacterSelected.ASTRONAUT)
        {
            target = GameObject.Find("Player2(Clone)").transform;
            Debug.Log(target);
            Debug.Log("Camera on astro");
        }
    }

    
}
