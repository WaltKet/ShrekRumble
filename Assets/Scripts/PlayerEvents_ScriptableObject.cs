using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PlayerEvents", menuName = "ScriptableObjects/PlayerEventsScriptableObject", order = 1)]
public class PlayerEvents_ScriptableObject : ScriptableObject
{
    private UnityEvent<PlayableCharacter> playerDeathEvent;
    private UnityEvent<PlayableCharacter> playerSpawnEvent;

    public UnityEvent<PlayableCharacter> PlayerDeathEvent => playerDeathEvent;
    public UnityEvent<PlayableCharacter> PlayerSpawnEvent => playerSpawnEvent;

    public void OnEnable()
    {
        playerDeathEvent = new UnityEvent<PlayableCharacter>();
        playerSpawnEvent = new UnityEvent<PlayableCharacter>();
    }

    private void OnDisable()
    {
        playerDeathEvent.RemoveAllListeners();
        playerSpawnEvent.RemoveAllListeners();
    }
}
