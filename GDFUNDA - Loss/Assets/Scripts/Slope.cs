using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slope : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && other.gameObject.GetComponent<Character>())
        {
            CharacterState charState = other.gameObject.GetComponent<Character>().GetState();
            if (charState == CharacterState.LeftArm || charState == CharacterState.RightArm)
                EventBroadcaster.Instance.PostEvent(EventNames.Dialogue_Events.IS_ONE_ARM_MOVING_AT_SLOPE);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            EventBroadcaster.Instance.PostEvent(EventNames.Dialogue_Events.DIALOGUE_OFF);
        }
    }
}
