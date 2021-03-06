using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    public const string InGameSceneName = "InGame";
    public const string OutGameSceneName = "OutGame";

    public void Resume()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        //SceneManager.LoadScene(InGameSceneName);
    }

    public void GoToOutGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(OutGameSceneName);
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
