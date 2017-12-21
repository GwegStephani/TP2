using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class MainHUD : MonoBehaviour {

    // UI Canvas for main canvas

    // UI Canvas for menu/item

    // UI Canvas for examin object


    public Canvas mainCanvas;
    public Canvas conversationCanvas;
    public Canvas menuCanvas;
    public Canvas ExamineCanvas;

    private Canvas activeCanvas;

    public Text infoText;


	// Use this for initialization
	void Start () {
        // hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // set main as active canvas
        activeCanvas = mainCanvas;
	}
	
	// Update is called once per frame
	void Update () {
        // hide cursor
        if (activeCanvas == mainCanvas) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        } else {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetButtonDown("Cancel")) {
            if (activeCanvas == conversationCanvas) {
                ChangeToDefaultCanvas ();
            }
        }
	}

    void OnEnable() {
        EventManager.StartListening(GameEvent.HoverTextShow.ToString(), ShowInfoText);
        EventManager.StartListening(GameEvent.HoverTextHide.ToString(), HideInfoText);
        EventManager.StartListening(GameEvent.CanvasChangeDefault.ToString(), ChangeToDefaultCanvas);
        EventManager.StartListening(GameEvent.CanvasChangeConvo.ToString(), ChangeToConverstationCanvas);
    }

    void OnDisable() {
        EventManager.StopListening(GameEvent.HoverTextShow.ToString(), ShowInfoText);
        EventManager.StopListening(GameEvent.HoverTextHide.ToString(), HideInfoText);
        EventManager.StopListening(GameEvent.CanvasChangeDefault.ToString(), ChangeToDefaultCanvas);
        EventManager.StopListening(GameEvent.CanvasChangeConvo.ToString(), ChangeToConverstationCanvas);
    }

    void ShowInfoText(object text) {
        if (infoText != null)
            infoText.text = text.ToString();
    }

    void HideInfoText() {
        if (infoText != null)
            infoText.text = "";
    }



    void ChangeToConverstationCanvas() {
        // get reference to player controller and disabled it
        FirstPersonController fpsController = GameObject.Find("FPSController").GetComponent<FirstPersonController>();
        if (fpsController != null) {
            fpsController.enabled = false;
        }

        // disable active canvas
        activeCanvas.gameObject.SetActive(false);

        // enabled convo canvas
        conversationCanvas.gameObject.SetActive(true);

        // set convo canvas as active canvas
        activeCanvas = conversationCanvas;

        // enable default input manager
    }

    void ChangeToDefaultCanvas() {
        // get reference to player controller and enable it
        FirstPersonController fpsController = GameObject.Find("FPSController").GetComponent<FirstPersonController>();
        if (fpsController != null) {
            fpsController.enabled = true;
        }

        // disable active canvas
        activeCanvas.gameObject.SetActive(false);

        // enable default canvas
        mainCanvas.gameObject.SetActive(true);

        // set main canvas as active canvas
        activeCanvas = mainCanvas;

        // enable LookInputModule
    }
}
