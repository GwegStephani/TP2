using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainHUD : MonoBehaviour {

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
        EventManager.StartListening(GameEvent.HoverTextShow, ShowInfoText);
        EventManager.StartListening(GameEvent.HoverTextHide, HideInfoText);
    }

    void OnDisable() {
        EventManager.StopListening(GameEvent.HoverTextShow, ShowInfoText);
        EventManager.StopListening(GameEvent.HoverTextHide, HideInfoText);
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
