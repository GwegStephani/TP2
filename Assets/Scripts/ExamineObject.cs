using UnityEngine;
using System.Collections;

public class ExamineObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void Trigger(Object target) {

        // get ui camera
        Camera[] camerasInScene = Camera.allCameras;
        Camera uiCamera = null;

        foreach (Camera currentCam in camerasInScene) {

            if (currentCam.name == "UICamera") {
                uiCamera = currentCam;
                break;
            }
        }

        if (uiCamera == null) { return; }

        //uiCamera.transform.forward.
        int test = 20;


        // move object in front of camera
        
        // set layer of object
        
        //
    }
}
