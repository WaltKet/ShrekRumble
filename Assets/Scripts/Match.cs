using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match 
{
    public int NumberOfPlayers { get; private set; }
    public string Stage { get; private set; }
    public int[] SelectedCharactersIds { get; private set; }

    public Match(int numberOfPlayers, string stage, int[] selectedCharactersIds)
    {
        NumberOfPlayers = numberOfPlayers;
        Stage = stage;
        SelectedCharactersIds = selectedCharactersIds;
    }
}
