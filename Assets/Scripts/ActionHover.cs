using UnityEngine;
using System.Collections;

public class ActionHover : MonoBehaviour {

    public string message;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Hover() {
        GUI.Label(new Rect((Screen.width - 60) / 2, (Screen.height - -20) / 2, 60, 50), message);
    }
}
