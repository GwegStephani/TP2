using UnityEngine;
using System.Collections;

public class EventTestDeleteMe2 : MonoBehaviour {

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

    void TestFunction(object age) {
        Debug.Log("I was triggered as a Test2!!! " + this.gameObject.name + " : " + age);
    }
}
