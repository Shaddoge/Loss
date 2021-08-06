using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    private static SceneController instance = null;
    private bool isDestroyingExisting = false;
    private void Start()
    {
        if (!instance)
            instance = this;
        else
            DestroyExistingSceneController();
        EventBroadcaster.Instance.AddObserver(EventNames.Scene_Controller_Events.RETURN_TO_MENU, LoadMainMenu);
        EventBroadcaster.Instance.AddObserver(EventNames.Game_Events.ON_ENDING_REACHED, LoadEndCredits);
        EventBroadcaster.Instance.AddObserver(EventNames.Game_Events.ON_ENDING_CREDITS_FINISHED, LoadMainMenu);
    }

    private void OnDestroy()
    {
        if(!isDestroyingExisting)
        {
            EventBroadcaster.Instance.RemoveObserver(EventNames.Scene_Controller_Events.RETURN_TO_MENU);
            EventBroadcaster.Instance.RemoveObserver(EventNames.Game_Events.ON_ENDING_REACHED);
            EventBroadcaster.Instance.RemoveObserver(EventNames.Game_Events.ON_ENDING_CREDITS_FINISHED);
        }
    }

    /*public void LoadGameScene()
    {
        SceneManager.LoadScene("Preload");
    }

    public void QuitApplication()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }*/

    private void LoadMainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");
    }

    private void LoadEndCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    private void DestroyExistingSceneController()
    {
        instance.isDestroyingExisting = true;
        EventBroadcaster.Instance.RemoveObserver(EventNames.Scene_Controller_Events.RETURN_TO_MENU);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Game_Events.ON_ENDING_REACHED);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Game_Events.ON_ENDING_CREDITS_FINISHED);
        Destroy(instance.gameObject);
        instance = this;
    }
}
