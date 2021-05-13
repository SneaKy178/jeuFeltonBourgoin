using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform target; 
    Vector3 offSet;
    private float smoothFactor;

    public void FixedUpdate()
    {
        offSet = new Vector3(0, 0, -10);
        smoothFactor = 30;
        Vector3 targetPosition = target.position + offSet;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.deltaTime);
        transform.position = target.position + offSet;
    }
    
}
