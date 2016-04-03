using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ActionHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public string message;

    private bool isHovering = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPointerEnter(PointerEventData eventData) {
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        isHovering = false;
    }

    void OnGUI() {
        if (isHovering)
            GUI.Label(new Rect((Screen.width - 60) / 2, (Screen.height - -20) / 2, 60, 50), message);
    }
}
