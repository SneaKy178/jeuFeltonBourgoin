using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;

    private CharacterSelected currentPlayerModel = CharacterSelected.KING; //Default character model, will be overwrited if different character chosen in character menu

    public enum CharacterSelected
    {
        KING,
        ASTRONAUT
    };

    public enum WorldSelected
    {
        WORLD1,
        WORLD2
    };

    public class WorldSelectionManager : UnityEvent<WorldSelected>{}

    public WorldSelectionManager worldSelectionManager = new WorldSelectionManager();
    
    public class CharacterSelectionManager: UnityEvent<CharacterSelected>{}

    public CharacterSelectionManager characterSelectionManager = new CharacterSelectionManager();

    public static GameManager Instance { get; private set; }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    
    

    // Start is called before the first frame update
    void Start()
    {
        Instance.worldSelectionManager.AddListener(worldSelection);
        Instance.characterSelectionManager.AddListener(selectePlayerModel);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }


    private void worldSelection(WorldSelected worldSelected)
    {
        Debug.Log("entered listener");
        if (worldSelected == WorldSelected.WORLD1)
        {
            SceneManager.LoadScene("Scenes/World_1");
        }

        if (worldSelected == WorldSelected.WORLD2)
        {
            SceneManager.LoadScene("Scenes/World_2");
        }
    }
    
    private void selectePlayerModel(CharacterSelected character)
    {
        currentPlayerModel = character;
    }

    public CharacterSelected getCurrentPlayerModel()
    {
        return currentPlayerModel;
    }
    
}