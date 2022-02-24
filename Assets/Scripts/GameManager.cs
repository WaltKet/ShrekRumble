using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : GenericSingletonClass<GameManager>
{
    public UIManager uIManager;
    PlayableCharacter[] CharactersInGame;
    public static UnityEvent<int> UICreate;
    // Start is called before the first frame update
    void Start()
    {
        CharactersInGame = FindObjectsOfType<PlayableCharacter>();
    }

    
    public void StartGame()
    {
        var uiMan = Instantiate(uIManager);
        SceneHelper.MoveGameObjectToScene("BattleScreenTest", uiMan.gameObject);
        uiMan.SetUIElements(GetCharactersInGame());
    }
    PlayableCharacter[] GetCharactersInGame()
    {
        return CharactersInGame;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildMatch(Match match)
    {
        
    }
}
