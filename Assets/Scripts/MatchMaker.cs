using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchMaker : GenericSingletonClass<MatchMaker>
{
    //Este script maneja la seleccion de personajes, y le envía la información al gameManager para que este
    // construya la partida.

    public int PlayerCount 
    {
        get => playerCount;
        set
        {
            playerCount = value;
            PlayerSelectedCharacter = new int[playerCount];
        }
    }

    private int playerCount;
    
    public string CurrentSelectedStage { get; set;}
    public int[] PlayerSelectedCharacter { get; set;}

    void StartMatch()
    {
        var match = GenerateMatchInfo();
        GameManager.Instance.BuildMatch(match);
    }
    

    public void PlayerLockCharacter(int playerId, int characterSelectedId)
    {
        PlayerSelectedCharacter[playerId] = characterSelectedId;
    }

    private bool AllPlayersLocked()
    {
        return false;
    }

    Match GenerateMatchInfo()
    {
        return new Match(PlayerCount, CurrentSelectedStage, PlayerSelectedCharacter);
    }
    
}
