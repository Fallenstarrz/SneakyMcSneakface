using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    //Load main menu
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    // Load game scene
    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
    // load credits
    public void LoadCredits()
    {
        SceneManager.LoadScene(2);
    }
    //exit game if built, otherwise log to console
    public void ExitGame()
    {
        Debug.Log("Exiting Program");
        Application.Quit();
    }
}
