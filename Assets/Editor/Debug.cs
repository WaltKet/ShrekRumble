using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Debug
{
    [MenuItem("Debug/StartGame")]
    public static void GameManagerStartGame()
    {
        if (Application.isPlaying)
        {
            Scene ManagementScene = SceneManager.GetSceneAt(1);
            GameManager gameManager = ManagementScene.GetRootGameObjects()[0].GetComponent<GameManager>();
            gameManager.StartGame();
        }
    }
}
