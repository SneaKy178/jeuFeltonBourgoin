using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuButton : MonoBehaviour
{
    [SerializeField] private MenuButtonController menuButtonController;

    [SerializeField] private Animator animator;
    

    [SerializeField] private int thisIndex;

    private GameManager _gameManager;

    private void Start()
    {
        
    }


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
                    _gameManager.worldSelectionManager.Invoke(GameManager.WorldSelected.WORLD1);
                    // SceneManager.LoadScene("Scenes/World1");
                }

                if (thisIndex == 1)
                {
                    _gameManager.worldSelectionManager.Invoke(GameManager.WorldSelected.WORLD1);
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
