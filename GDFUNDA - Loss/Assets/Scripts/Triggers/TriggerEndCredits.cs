using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEndCredits : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(TriggerEndOnTimer());
        }
    }

    private IEnumerator TriggerEndOnTimer()
    {
        yield return new WaitForSeconds(0.5f);
        EventBroadcaster.Instance.PostEvent(EventNames.Game_Events.ON_ENDING_REACHED);
    }
    
}
