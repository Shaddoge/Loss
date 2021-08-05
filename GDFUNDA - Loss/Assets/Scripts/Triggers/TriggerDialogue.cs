using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Dialogue {
    OnRoomOneEnter,
    OnRoomTwoEnter,
    OnRoomThreeEnter,
    OnRoomEndEnter,
    OnArmFound,
    OnLegsFound
}


public class TriggerDialogue : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            switch (dialogue)
            {
                case Dialogue.OnRoomOneEnter: EventBroadcaster.Instance.PostEvent(EventNames.Dialogue_Events.ON_ROOM_ONE_ENTER); break;
                case Dialogue.OnRoomTwoEnter: EventBroadcaster.Instance.PostEvent(EventNames.Dialogue_Events.ON_ROOM_TWO_ENTER); break;
                case Dialogue.OnRoomThreeEnter: EventBroadcaster.Instance.PostEvent(EventNames.Dialogue_Events.ON_ROOM_THREE_ENTER); break;
                case Dialogue.OnRoomEndEnter: EventBroadcaster.Instance.PostEvent(EventNames.Dialogue_Events.ON_ROOM_END_ENTER); break;
                case Dialogue.OnArmFound: EventBroadcaster.Instance.PostEvent(EventNames.Dialogue_Events.ON_ARM_FOUND); break;
                case Dialogue.OnLegsFound: EventBroadcaster.Instance.PostEvent(EventNames.Dialogue_Events.ON_LEGS_FOUND); break;
            }

            Destroy(this);
        }
    }
}
