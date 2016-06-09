using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainHUD : MonoBehaviour {

    // UI Canvas for main canvas

    // UI Canvas for menu/item

    // UI Canvas for examin object


    public Canvas mainCanvas;
    public Canvas menuCanvas;
    public Canvas ExamineCanvas;

    private Canvas activeCanvas;

    public Text infoText;

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
    }

    void OnDisable() {
        EventManager.StopListening(GameEvent.HoverTextShow.ToString(), ShowInfoText);
        EventManager.StopListening(GameEvent.HoverTextHide.ToString(), HideInfoText);
    }

    void ShowInfoText(object text) {
        if (infoText != null)
            infoText.text = text.ToString();
    }

    void HideInfoText() {
        if (infoText != null)
            infoText.text = "";
    }
}
