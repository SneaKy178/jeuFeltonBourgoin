using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;


    private PlayerScript _playerScript;

    [SerializeField] private Sprite[] characterSprites;

    public enum CharacterSelected
    {
        KING,
        ASTRONAUT,
        WARRIOR
    };

    public enum WorldSelected
    {
        WORLD1,
        WORLD2
    };

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void worldSelection()
    {
        if (Enum.IsDefined(typeof(WorldSelected), WorldSelected.WORLD1 ))
        {
            SceneManager.LoadScene("World1");
        }else if (Enum.IsDefined(typeof(WorldSelected), WorldSelected.WORLD2))
        {
            SceneManager.LoadScene("world2");
        }
    }


    private void characterSelection()
    {
        
        if (Enum.IsDefined(typeof(CharacterSelected), CharacterSelected.KING))
        {
            _playerScript.playerSprite = characterSprites[0];
        }
        else if (Enum.IsDefined(typeof(CharacterSelected), CharacterSelected.ASTRONAUT))
        {
            _playerScript.playerSprite = characterSprites[1];
        }
        else if (Enum.IsDefined(typeof(CharacterSelected), CharacterSelected.WARRIOR))
        {
            _playerScript.playerSprite = characterSprites[2];
        }
    }
}