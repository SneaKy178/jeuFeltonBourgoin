using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMenuButton : MonoBehaviour
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
                    GameManager.Instance.characterSelectionManager.Invoke(GameManager.CharacterSelected.KING);
                }

                if (thisIndex == 1)
                {
                    GameManager.Instance.characterSelectionManager.Invoke(GameManager.CharacterSelected.ASTRONAUT);
                }

                if (thisIndex == 2)
                {
                    GameManager.Instance.characterSelectionManager.Invoke(GameManager.CharacterSelected.WARRIOR);
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
