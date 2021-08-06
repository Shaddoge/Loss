using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager instance = null;

    private GameObject pauseMenu;
    private GameObject crosshair;
    private GameObject guide;
    private GameObject dialogue;
    private int queue = 0;

    public static bool isPaused = false;


    private void Start()
    {
        if (!instance)
            instance = this;
        else
            DestroyExistingUIManager();

        pauseMenu = transform.Find("Pause Menu").gameObject;
        crosshair = transform.Find("Crosshair").gameObject;
        guide = transform.Find("Guide").gameObject;
        dialogue = transform.Find("Dialogue").gameObject;
        
        EventBroadcaster.Instance.AddObserver(EventNames.DESTROY_UI, this.DestroyCurrentUIManager);

        //Guide
        EventBroadcaster.Instance.AddObserver(EventNames.Guide_Events.BUTTON_IN_RANGE, this.ButtonGuideEnable);
        EventBroadcaster.Instance.AddObserver(EventNames.Guide_Events.PICKABLE_IN_RANGE, this.PickableGuideEnable);
        EventBroadcaster.Instance.AddObserver(EventNames.Guide_Events.PUSHABLE_IN_RANGE, this.PushableGuideEnable);
        EventBroadcaster.Instance.AddObserver(EventNames.Guide_Events.OUT_OF_RANGE, this.GuideDisable);
        //Dialogue
        EventBroadcaster.Instance.AddObserver(EventNames.Dialogue_Events.IS_ONE_ARM_PUSHING, this.OneArmPushing);
        EventBroadcaster.Instance.AddObserver(EventNames.Dialogue_Events.ON_ROOM_SPAWN_ENTER, this.OnRoomSpawnEnter);
        EventBroadcaster.Instance.AddObserver(EventNames.Dialogue_Events.ON_ROOM_ONE_ENTER, this.OnRoomOneEnter);
        EventBroadcaster.Instance.AddObserver(EventNames.Dialogue_Events.ON_ROOM_TWO_ENTER, this.OnRoomTwoEnter);
        EventBroadcaster.Instance.AddObserver(EventNames.Dialogue_Events.ON_ROOM_THREE_ENTER, this.OnRoomThreeEnter);
        EventBroadcaster.Instance.AddObserver(EventNames.Dialogue_Events.ON_LEFT_ARM_FOUND, this.OnLeftArmFound);
        EventBroadcaster.Instance.AddObserver(EventNames.Dialogue_Events.ON_RIGHT_ARM_FOUND, this.OnRightArmFound);
        EventBroadcaster.Instance.AddObserver(EventNames.Dialogue_Events.ON_LEGS_FOUND, this.OnLegsFound);
        EventBroadcaster.Instance.AddObserver(EventNames.Dialogue_Events.DIALOGUE_OFF, this.DialogueDisable);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.DESTROY_UI);

        EventBroadcaster.Instance.RemoveObserver(EventNames.Guide_Events.BUTTON_IN_RANGE);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Guide_Events.PICKABLE_IN_RANGE);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Guide_Events.PUSHABLE_IN_RANGE);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Guide_Events.OUT_OF_RANGE);

        EventBroadcaster.Instance.RemoveObserver(EventNames.Dialogue_Events.IS_ONE_ARM_PUSHING);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Dialogue_Events.ON_ROOM_SPAWN_ENTER);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Dialogue_Events.ON_ROOM_ONE_ENTER);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Dialogue_Events.ON_ROOM_TWO_ENTER);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Dialogue_Events.ON_ROOM_THREE_ENTER);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Dialogue_Events.ON_LEFT_ARM_FOUND);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Dialogue_Events.ON_RIGHT_ARM_FOUND);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Dialogue_Events.ON_LEGS_FOUND);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Dialogue_Events.DIALOGUE_OFF);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        isPaused = false;
        EventBroadcaster.Instance.PostEvent(EventNames.DESTROY_PLAYER);
        EventBroadcaster.Instance.PostEvent(EventNames.Scene_Controller_Events.RETURN_TO_MENU);
        DestroyCurrentUIManager();
    }

    private void ButtonGuideEnable()
    {
        crosshair.GetComponent<Image>().color = new Color32(100, 255, 255, 255);
        guide.GetComponent<Text>().text = "[E] Push Button";
        guide.SetActive(true);
    }

    private void PickableGuideEnable()
    {
        crosshair.GetComponent<Image>().color = new Color32(100, 255, 255, 255);
        guide.GetComponent<Text>().text = "[M1] Pick-up Object";
        guide.SetActive(true);
    }

    private void PushableGuideEnable()
    {
        crosshair.GetComponent<Image>().color = new Color32(100, 255, 255, 255);
        guide.GetComponent<Text>().text = "[M1] Push/Pull Object";
        guide.SetActive(true);
    }

    private void GuideDisable()
    {
        crosshair.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        guide.SetActive(false);
    }

    private void OnRoomSpawnEnter()
    {
        dialogue.GetComponent<Text>().text = "Where are my limbs? Wait, my arm is nearby. I should reattach it to my body.";
        dialogue.SetActive(true);
        this.StartCoroutine(this.DialogueDisableTimer(10.0f));
    }

    private void OnRoomOneEnter()
    {
        dialogue.GetComponent<Text>().text = "I think I can pick up these cubes.";
        dialogue.SetActive(true);
        this.StartCoroutine(this.DialogueDisableTimer(4.0f));
    }

    private void OnRoomTwoEnter()
    {
        dialogue.GetComponent<Text>().text = "I can finally clear this path";
        dialogue.SetActive(true);
        this.StartCoroutine(this.DialogueDisableTimer(5.0f));
    }

    private void OnRoomThreeEnter()
    {
        dialogue.GetComponent<Text>().text = "I can see the light at the other side. I can finally get out of this place.";
        dialogue.SetActive(true);
        this.StartCoroutine(this.DialogueDisableTimer(7.0f));
    }

    private void OnLeftArmFound()
    {
        
        dialogue.GetComponent<Text>().text = "I should be able to grab some objects with this.";
        dialogue.SetActive(true);
        this.StartCoroutine(this.DialogueDisableTimer(5.0f));
    }

    private void OnRightArmFound()
    {
        dialogue.GetComponent<Text>().text = "I should be able to push objects with my arms now.";
        dialogue.SetActive(true);
        this.StartCoroutine(this.DialogueDisableTimer(4.0f));
    }

    private void OnLegsFound()
    {
        
        dialogue.GetComponent<Text>().text = "I can jump with my legs now. It's time to escape this place.";
        dialogue.SetActive(true);
        this.StartCoroutine(this.DialogueDisableTimer(6.0f));
    }

    private void OneArmPushing()
    {
        dialogue.GetComponent<Text>().text = "I only have one arm. I should find my other arm.";
        dialogue.SetActive(true);
    }

    private void DialogueDisable()
    {
        dialogue.SetActive(false);
    }

    private IEnumerator DialogueDisableTimer(float timer)
    {
        queue++;
        yield return new WaitForSeconds(timer);
        queue--;

        if(queue <= 0)
            dialogue.SetActive(false);
    }

    private void DestroyExistingUIManager()
    {
        Destroy(instance.gameObject);
        instance = this;
    }

    private void DestroyCurrentUIManager()
    {
        instance = null;
        Destroy(this.gameObject);
    }
}
