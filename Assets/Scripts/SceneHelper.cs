using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneHelper
{
    public static void MoveGameObjectToScene(string sceneName, GameObject gO)
    {
        SceneManager.MoveGameObjectToScene(gO, SceneManager.GetSceneByName(sceneName));
    }
}
