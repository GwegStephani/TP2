using UnityEngine;
using System.Collections;

public class ActionInspect : MonoBehaviour {

    Transform originalTransform;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Clicked(string option) {
        Debug.Log("ActionInspect clicked!");

        // save original transform
        originalTransform = this.transform;

        // find inspect camera
        GameObject camera = GameObject.Find("InspectCamera");

        if (camera) {

            // move or duplicate object to camera
            this.transform.position = camera.transform.position;

            this.transform.position += camera.transform.forward * 3.0f;

            
            // enable inspect canvas and camera
        }



    }
}
