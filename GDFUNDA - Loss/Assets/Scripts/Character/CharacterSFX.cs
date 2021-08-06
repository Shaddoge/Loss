using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSFX : MonoBehaviour
{
    [SerializeField] private AudioClip OnRoomSpawnEnter;
    [SerializeField] private AudioClip OnRoomOneEnter;
    [SerializeField] private AudioClip OnRoomTwoEnter;
    [SerializeField] private AudioClip OnRoomThreeEnter;
    [SerializeField] private AudioClip OnRoomEndEnter;
    [SerializeField] private AudioClip OnLeftArmFound;
    [SerializeField] private AudioClip OnRightArmFound;
    [SerializeField] private AudioClip OnLegsFound;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();

        //Dialogue
        EventBroadcaster.Instance.AddObserver(EventNames.Dialogue_Events.ON_ROOM_SPAWN_ENTER,   this.PlayOnRoomSpawnEnter);
        EventBroadcaster.Instance.AddObserver(EventNames.Dialogue_Events.ON_ROOM_ONE_ENTER,     this.PlayOnRoomOneEnter);
        EventBroadcaster.Instance.AddObserver(EventNames.Dialogue_Events.ON_ROOM_TWO_ENTER,     this.PlayOnRoomTwoEnter);
        EventBroadcaster.Instance.AddObserver(EventNames.Dialogue_Events.ON_ROOM_THREE_ENTER,   this.PlayOnRoomThreeEnter);
        EventBroadcaster.Instance.AddObserver(EventNames.Dialogue_Events.ON_ROOM_END_ENTER,     this.PlayOnRoomEndEnter);
        EventBroadcaster.Instance.AddObserver(EventNames.Dialogue_Events.ON_LEFT_ARM_FOUND,     this.PlayOnLeftArmFound);
        EventBroadcaster.Instance.AddObserver(EventNames.Dialogue_Events.ON_RIGHT_ARM_FOUND,    this.PlayOnRightArmFound);
        EventBroadcaster.Instance.AddObserver(EventNames.Dialogue_Events.ON_LEGS_FOUND,         this.PlayOnLegsFound);

    }

    private void PlayOnRoomSpawnEnter()
    {
        audioSource.clip = OnRoomSpawnEnter;
        audioSource.Play();
        StartCoroutine(RemoveObserverTimer(EventNames.Dialogue_Events.ON_ROOM_SPAWN_ENTER));
    }

    private void PlayOnRoomOneEnter()
    {
        audioSource.clip = OnRoomOneEnter;
        audioSource.Play();
        StartCoroutine(RemoveObserverTimer(EventNames.Dialogue_Events.ON_ROOM_ONE_ENTER));
    }

    private void PlayOnRoomTwoEnter()
    {
        audioSource.clip = OnRoomTwoEnter;
        audioSource.Play();
        StartCoroutine(RemoveObserverTimer(EventNames.Dialogue_Events.ON_ROOM_TWO_ENTER));
    }

    private void PlayOnRoomThreeEnter()
    {
        audioSource.clip = OnRoomThreeEnter;
        audioSource.Play();
        StartCoroutine(RemoveObserverTimer(EventNames.Dialogue_Events.ON_ROOM_THREE_ENTER));
    }

    private void PlayOnRoomEndEnter()
    {
        audioSource.clip = OnRoomEndEnter;
        audioSource.Play();
        StartCoroutine(RemoveObserverTimer(EventNames.Dialogue_Events.ON_ROOM_END_ENTER));
    }

    private void PlayOnLeftArmFound()
    {
        audioSource.clip = OnLeftArmFound;
        audioSource.Play();
        StartCoroutine(RemoveObserverTimer(EventNames.Dialogue_Events.ON_LEFT_ARM_FOUND));
    }

    private void PlayOnRightArmFound()
    {
        audioSource.clip = OnRightArmFound;
        audioSource.Play();
        StartCoroutine(RemoveObserverTimer(EventNames.Dialogue_Events.ON_RIGHT_ARM_FOUND));
    }

    private void PlayOnLegsFound()
    {
        audioSource.clip = OnLegsFound;
        audioSource.Play();
        StartCoroutine(RemoveObserverTimer(EventNames.Dialogue_Events.ON_LEGS_FOUND));
    }

    IEnumerator RemoveObserverTimer(string observer)
    {
        yield return new WaitForSeconds(2.0f);
        EventBroadcaster.Instance.RemoveObserver(observer);
    }
}
