using UnityEngine;
using System.Collections;

public class EventTestDeleteMe : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable() {
        EventManager.StartListening("test", TestFunction);
    }

    void OnDisable() {
        EventManager.StopListening("test", TestFunction);
    }

    void TestFunction() {
        Debug.Log("I was triggered as a Test!!! " + this.gameObject.name);
    }
}
