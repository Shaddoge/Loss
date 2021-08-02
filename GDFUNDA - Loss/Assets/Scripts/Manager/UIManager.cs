using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject pauseMenu;
    private GameObject crosshair;
    private GameObject guide;
    private GameObject dialogue;

    public static bool isPaused = false;

    private void Start()
    {
        pauseMenu = transform.Find("Pause Menu").gameObject;
        crosshair = transform.Find("Crosshair").gameObject;
        guide = transform.Find("Guide").gameObject;
        dialogue = transform.Find("Dialogue").gameObject;

        EventBroadcaster.Instance.AddObserver(EventNames.Guide_Events.BUTTON_IN_RANGE, this.ButtonGuideEnable);
        EventBroadcaster.Instance.AddObserver(EventNames.Guide_Events.PICKABLE_IN_RANGE, this.PickableGuideEnable);
        EventBroadcaster.Instance.AddObserver(EventNames.Guide_Events.PUSHABLE_IN_RANGE, this.PushableGuideEnable);
        EventBroadcaster.Instance.AddObserver(EventNames.Guide_Events.OUT_OF_RANGE, this.GuideDisable);

        EventBroadcaster.Instance.AddObserver(EventNames.Dialogue_Events.IS_ONE_ARM_MOVING_AT_SLOPE, this.OneArmMovingAtSlopeDialogueEnable);
        EventBroadcaster.Instance.AddObserver(EventNames.Dialogue_Events.DIALOGUE_OFF, this.DialogueDisable);

    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.Guide_Events.BUTTON_IN_RANGE);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Guide_Events.PICKABLE_IN_RANGE);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Guide_Events.PUSHABLE_IN_RANGE);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Guide_Events.OUT_OF_RANGE);

        EventBroadcaster.Instance.RemoveObserver(EventNames.Dialogue_Events.IS_ONE_ARM_MOVING_AT_SLOPE);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Dialogue_Events.DIALOGUE_OFF);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
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
        guide.GetComponent<Text>().text = "[E] Push/Pull Object";
        guide.SetActive(true);
    }

    private void GuideDisable()
    {
        crosshair.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        guide.SetActive(false);
    }

    private void OneArmMovingAtSlopeDialogueEnable()
    {
        dialogue.GetComponent<Text>().text = "I only have one arm. I should find my other arm.";
        dialogue.SetActive(true);
    }

    private void DialogueDisable()
    {
        dialogue.SetActive(false);
    }
}
