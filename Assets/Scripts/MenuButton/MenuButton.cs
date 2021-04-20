using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private MenuButtonController menuButtonController;

    [SerializeField] private Animator animator;
    

    [SerializeField] private int thisIndex;
    

    // Update is called once per frame
    void Update()
    {
        if (menuButtonController.index == thisIndex)
        {
            animator.SetBool("IsSelected", true);
            if (Input.GetAxis("Submit") == 1)
            {
                animator.SetBool("IsPressed", true);
                if (thisIndex == 0)
                {
                    SceneManager.LoadScene("Scenes/World1");
                }
            }
            else if(animator.GetBool("IsPressed"))
            {
                animator.SetBool("IsPressed", false);
            }
        }
        else
        {
            animator.SetBool("IsSelected", false);
        }
    }
}
