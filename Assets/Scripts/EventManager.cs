using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void PlayerDeathEvent(GameObject playerCharacter);
    public static event PlayerDeathEvent playerDeathEvent;

    public delegate void PlayerSpawnEvent();
    public static event PlayerSpawnEvent playerSpawnEvent;

    public static void PlayerDeath(GameObject playerCharacter)
    {
        playerDeathEvent(playerCharacter);
    }

    public static void playerSpawn()
    {
        playerSpawnEvent();
    }
}
