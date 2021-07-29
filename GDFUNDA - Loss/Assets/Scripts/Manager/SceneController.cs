using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }

    public void LoadCredits()
    {
        Debug.Log("No Credits Yet LMAO");
    }

    public void LoadRoom1()
    {
        SceneManager.LoadScene("RoomScene");
    }

    public void LoadRoom2()
    {
        SceneManager.LoadScene("Room2");
    }
}
