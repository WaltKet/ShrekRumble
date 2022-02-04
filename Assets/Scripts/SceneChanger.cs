using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class is in charge of changing scenes on a button press
/// </summary>
public class SceneChanger : MonoBehaviour
{
    void Start()
    {
        //Makes this gameObject not be deleted on 
        DontDestroyOnLoad(this.gameObject);
    }

    /// <summary>
    /// Loads character selection screen scene
    /// </summary>
    public void LoadCharacterScreen()
    {
        SceneManager.LoadScene("CharacterSelection");
    }
    /// <summary>
    /// Loads the battle screen scene
    /// </summary>
    public void LoadBattleScreen()
    {
        SceneManager.LoadScene("BattleScreenTest");
    }

    /// <summary>
    /// Loads end screen scene
    /// </summary>
    public void EndScreen()
    {
        SceneManager.LoadScene("EndScreen");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
