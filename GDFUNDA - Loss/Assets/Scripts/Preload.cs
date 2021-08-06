using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Preload : MonoBehaviour
{
    [SerializeField] private List<string> scenesToLoad = new List<string>();
    private Image image;
    // Start is called before the first frame update
    private void Start()
    {
        image = this.GetComponent<Image>();
        StartCoroutine(LoadAllScenes());
    }

    private IEnumerator LoadAllScenes()
    {
        int count = scenesToLoad.Count;
        foreach(string scene in scenesToLoad)
        {
            AsyncOperation load = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            load.allowSceneActivation = false;
            while (!load.isDone)
            {
                image.fillAmount = load.progress / count;
                if (load.progress >= 0.9f)
                    load.allowSceneActivation = true;
                yield return null;
            }
            count--;
            if (SceneManager.GetSceneByName(scene).buildIndex != 2)
            {
                foreach (GameObject gameObject in SceneManager.GetSceneByName(scene).GetRootGameObjects())
                {
                    gameObject.SetActive(false);
                }
            }
        }
        foreach (GameObject gameObject in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            Destroy(gameObject);
        }
    }
}
