using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void SpawnPlayer(GameObject player)
    {
        StartCoroutine(Spawn(player));
    }

    private IEnumerator Spawn(GameObject player)
    {
        yield return new WaitForSeconds(respawnTime);
        EventManager.playerSpawn();
        player.transform.position = gameObject.transform.position;
        player.GetComponent<PlayableCharacter>().Invincible = true;
        yield return new WaitForSeconds(playerInvicibleTime);
        player.GetComponent<PlayableCharacter>().Invincible = false;

    }
}
