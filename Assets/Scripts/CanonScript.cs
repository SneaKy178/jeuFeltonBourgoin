using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonScript : MonoBehaviour
{
    [SerializeField] private Transform firePosition;
    [SerializeField] private Transform bulletPrefab;
    private double timeRemaining = 0.5;
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            shoot();
            timeRemaining = 1;
        }
        
    }

    public void shoot()
    {
        Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
    }
}
