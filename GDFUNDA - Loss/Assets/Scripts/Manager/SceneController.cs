using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    private void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.Scene_Controller_Events.RETURN_TO_MENU, LoadMainMenu);
        EventBroadcaster.Instance.AddObserver(EventNames.Game_Events.ON_ENDING_REACHED, LoadEndCredits);
        EventBroadcaster.Instance.AddObserver(EventNames.Game_Events.ON_ENDING_CREDITS_FINISHED, LoadMainMenu);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.Scene_Controller_Events.RETURN_TO_MENU);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Game_Events.ON_ENDING_REACHED);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Game_Events.ON_ENDING_CREDITS_FINISHED);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Preload");
    }

    public void QuitApplication()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }

    private void LoadMainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("Hello");
        SceneManager.LoadScene("MainMenu");
        Destroy(this.gameObject);
    }

    private void LoadEndCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
