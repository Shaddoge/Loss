using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEndCredits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreditsTimer());
    }

    private IEnumerator CreditsTimer()
    {
        yield return new WaitForSeconds(23.0f);
        Debug.Log("Quit to Menu");
        EventBroadcaster.Instance.PostEvent(EventNames.Scene_Controller_Events.RETURN_TO_MENU);
    }
}
