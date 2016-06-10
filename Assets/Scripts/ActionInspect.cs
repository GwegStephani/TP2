using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class ActionInspect : MonoBehaviour {

    Transform originalTransform;
    GameObject inspectCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetInput();
	}


    private void GetInput() {
        float xRotation = CrossPlatformInputManager.GetAxis("Mouse X");
        float yRotation = CrossPlatformInputManager.GetAxis("Mouse Y");

        this.transform.Rotate(Vector3.up, -xRotation);
        this.transform.Rotate(Vector3.right, yRotation);
    }

    void Clicked(string option) {
        Debug.Log("ActionInspect clicked!");

        // save original transform
        originalTransform = this.transform;


        // find InspectObject script

        // find inspect camera
        this.inspectCamera = GameObject.Find("InspectCamera");

        //this.inspectCamera.SendMessage("Click


        if (inspectCamera) {

            // move or duplicate object to camera
            this.transform.position = inspectCamera.transform.position;

            this.transform.position += inspectCamera.transform.forward * 3.0f;

            
            // enable inspect canvas and camera
        }
    }
}
