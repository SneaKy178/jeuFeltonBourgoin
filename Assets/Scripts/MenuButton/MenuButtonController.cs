using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour
{
    public int index;
    private bool isKeyDown;
    [SerializeField] private bool useSideKeys;
    [SerializeField] private int maxIndex;

    private string axisUsed;

    private int axisMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        if (useSideKeys)
        {
            axisUsed = "Horizontal";
            axisMultiplier = -1;
        }
        else
        {
            axisUsed = "Vertical";
            axisMultiplier = 1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(axisUsed) != 0)
        {
            if (!isKeyDown)
            {
                if (Input.GetAxis(axisUsed) * axisMultiplier < 0)
                {
                    if (index < maxIndex)
                    {
                        index++;
                    }
                    else
                    {
                        index = 0;
                    }
                }
                else if (Input.GetAxis(axisUsed) * axisMultiplier > 0)
                {
                    if (index > 0)
                    {
                        index--;
                    }
                    else
                    {
                        index = maxIndex;
                    }
                }

                isKeyDown = true;
            }
        }else
        {
            isKeyDown = false;
        }
        
    }
}
