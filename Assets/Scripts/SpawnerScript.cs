using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//El nombre de la clase debe representar el objeto con el que trabaja. Si es con un jugador debería ser PlayerSpawnerScript
public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    private float respawnTime;
    [SerializeField]
    private float playerInvicibleTime;

    private void OnEnable()
    {
        EventManager.playerDeathEvent += SpawnPlayer;
    }

    private void SpawnPlayer(GameObject player) // Si el objeto que pasa en el parametro es un jugador deberia pasarse en esa forma, no como Gameobject.
                                                // Cambiar GameObject -> PlayableCharacter
    {
        StartCoroutine(Spawn(player));
    }

    private IEnumerator Spawn(GameObject player) // El nombre de la funcion debe indicar con el tipo de objeto con el que se trabaja. 
                                                // Si la funcion es una corrutina deberia indicarse en el nombre.
                                                // Cambiar Spawn -> SpawnPlayerCoroutine o SpawnPlayerCO o como se guste y prefiera
    {
        yield return new WaitForSeconds(respawnTime);
        EventManager.playerSpawn();
        player.transform.position = gameObject.transform.position;
        player.GetComponent<PlayableCharacter>().Invincible = true; // Si el parametro lo pasas en la forma de PlayableCharacter no hay necesidad de usar GetComponent
        yield return new WaitForSeconds(playerInvicibleTime);       // La funcion Spawn no debe ser la encargada de hacer invulnerable a un jugador. Separar la funcion
        player.GetComponent<PlayableCharacter>().Invincible = false;
        //Recuerda Usar la S en SOLID. Single Resposabilitie.
    }
}
