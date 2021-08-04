using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSFX : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip OnRoomThreeEnter;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();

        //Dialogue
        EventBroadcaster.Instance.AddObserver(EventNames.Dialogue_Events.ON_ROOM_THREE_ENTER, this.PlayOnRoomThreeEnter);
    }

    private void PlayOnRoomThreeEnter()
    {
        audioSource.clip = OnRoomThreeEnter;
        audioSource.Play();
    }
}
