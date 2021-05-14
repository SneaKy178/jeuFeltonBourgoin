using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    [SerializeField] private Transform spawnPoint;

    [SerializeField] private Transform kingPrefab;
    [SerializeField] private Transform astronautPrefab;
    [SerializeField] private Transform warriorPrefab;
    // Start is called before the first frame update
    void Start()
    {
        instantiateSelectedCharacter(GameManager.Instance.getCurrentPlayerModel());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void instantiateSelectedCharacter(GameManager.CharacterSelected characterSelected)
    {
        if (characterSelected == GameManager.CharacterSelected.KING)
        {
            Instantiate(kingPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        
        if (characterSelected == GameManager.CharacterSelected.ASTRONAUT)
        {
            Instantiate(astronautPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        
        if (characterSelected == GameManager.CharacterSelected.WARRIOR)
        {
            Instantiate(warriorPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
