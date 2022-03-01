using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match 
{
    public int NumberOfPlayers
    {
        get
        {
            return numberOfPlayers;
        }
        set
        {
            numberOfPlayers = value;
        }
    }

    public string Stage
    {
        get
        {
            return stage;
        }
        set
        {
            stage = value;
        }
    }

    public int[] SelectedCharactersIds
    {
        get
        {
            return selectedCharactersIds;
        }
        set
        {
            selectedCharactersIds = value;
        }
    }

    private int numberOfPlayers;
    private string stage;
    private int[] selectedCharactersIds;

    public Match(int numberOfPlayers, string stage, int[] selectedCharactersIds)
    {
        NumberOfPlayers = numberOfPlayers;
        Stage = stage;
        SelectedCharactersIds = selectedCharactersIds;
    }
}
