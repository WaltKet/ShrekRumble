using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void PlayerDeathEvent(GameObject playerCharacter);
    public static event PlayerDeathEvent playerDeathEvent;

    public delegate void PlayerSpawnEvent();
    public static event PlayerSpawnEvent playerSpawnEvent;

    //Generalmente cuando se trata de eventos la gente suele poner la palabra "On" previo al nombre -> OnPlayerDeathEvent;
    public static void PlayerDeath(GameObject playerCharacter) // El parametro se puede pasar en la forma que es PlayableCharacter.
    {
        playerDeathEvent(playerCharacter); // Este objeto es nulo. Se debe incializar primero y prefiere el metodo Invoke para llamar un evento
        /* playerDeathEvent.Invoke(playerCharacter); Incluso si se usa Invoke se debe revisar si es nulo el evento
         
         if(playerDeathEvent != null)
             playerDeathEvent.Invoke(playarCharacter); Esto se puede simplificar de la siguiente forma.
             
         playerDeathEvent?.Invoke(playerCharacter);
         
         */
       
    }

    public static void playerSpawn() // Acostumbra a usar la misma convencion y estilo para nombrar funciones. Ya corregi otros que habia pero este lo dejo como ejemplo. 
                                    // Cambiar playerSpawn -> PlayerSpawn
    {
        playerSpawnEvent();
    }
}
