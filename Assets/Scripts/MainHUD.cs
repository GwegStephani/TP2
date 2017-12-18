using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class MainHUD : MonoBehaviour {

    // UI Canvas for main canvas

    // UI Canvas for menu/item

    // UI Canvas for examin object


    public Canvas mainCanvas;
    public Canvas menuCanvas;
    public Canvas ExamineCanvas;

    private Canvas activeCanvas;

    public Text infoText;

    public enum CanvasType {
        Default,
        Convo
    };


	// Use this for initialization
	void Start () {
        // hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        // hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}

    void OnEnable() {
        EventManager.StartListening(GameEvent.HoverTextShow.ToString(), ShowInfoText);
        EventManager.StartListening(GameEvent.HoverTextHide.ToString(), HideInfoText);
        EventManager.StartListening(GameEvent.CanvasChange.ToString(), CanvasChange);
    }

    void OnDisable() {
        EventManager.StopListening(GameEvent.HoverTextShow.ToString(), ShowInfoText);
        EventManager.StopListening(GameEvent.HoverTextHide.ToString(), HideInfoText);
        EventManager.StopListening(GameEvent.CanvasChange.ToString(), CanvasChange);
    }

    void ShowInfoText(object text) {
        if (infoText != null)
            infoText.text = text.ToString();
    }

    void HideInfoText() {
        if (infoText != null)
            infoText.text = "";
    }

    void CanvasChange(object canvasType) {
        switch ((CanvasType)canvasType) {
        case CanvasType.Convo:
            ChangeToConverstationCanvas();
            break;
        default:
            break;
        }

    }

    void ChangeToConverstationCanvas() {
        // get reference to player controller and disabled it
        FirstPersonController fpsController = GameObject.Find("FPSController").GetComponent<FirstPersonController>();
        if (fpsController != null) {
            fpsController.enabled = false;
        }

        // enabled convo canvas

        // disabled all others

        // enabled mouse

        // enable default input manager
    }

    void ChangeToDefaultCanvas() {
        // get reference to player controller and enable it
        FirstPersonController fpsController = GameObject.Find("FPSController").GetComponent<FirstPersonController>();
        if (fpsController != null) {
            fpsController.enabled = true;
        }

        // enable default canvas

        // disabled all others

        // disable mouse

        // enable LookInputModule
    }
}
