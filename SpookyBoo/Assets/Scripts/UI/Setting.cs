using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    public const string InGameSceneName = "";
    public const string OutGameSceneName = "";



    public void Resume()
    {
        SceneManager.LoadScene(InGameSceneName);
    }

    public void GoToOutGame()
    {
        SceneManager.LoadScene(OutGameSceneName);
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
