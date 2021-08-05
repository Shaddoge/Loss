using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Dialogue {
    OnRoomOneEnter,
    OnRoomTwoEnter,
    OnRoomThreeEnter,
    OnRoomEndEnter,
    OnLeftArmFound,
    OnRightArmFound,
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
                case Dialogue.OnLeftArmFound: EventBroadcaster.Instance.PostEvent(EventNames.Dialogue_Events.ON_LEFT_ARM_FOUND); break;
                case Dialogue.OnRightArmFound: EventBroadcaster.Instance.PostEvent(EventNames.Dialogue_Events.ON_RIGHT_ARM_FOUND); break;
                case Dialogue.OnLegsFound: EventBroadcaster.Instance.PostEvent(EventNames.Dialogue_Events.ON_LEGS_FOUND); break;
            }

            Destroy(this);
        }
    }
}
