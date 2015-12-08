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



        //this.transform.Rotate(new Vector3(5, 0, 0));

        this.transform.RotateAround(inspectCamera.transform.up, -xRotation);
        this.transform.RotateAround(inspectCamera.transform.right, yRotation);

        //this.transform.RotateAround(Camera.main.transform.up, -Mathf.Deg2Rad * yRotation * 10);
        //this.transform.RotateAround(Camera.main.transform.right, Mathf.Deg2Rad * xRotation * 10);

    }

    void Clicked(string option) {
        Debug.Log("ActionInspect clicked!");

        // save original transform
        originalTransform = this.transform;

        // find inspect camera
        this.inspectCamera = GameObject.Find("InspectCamera");

        if (inspectCamera) {

            // move or duplicate object to camera
            this.transform.position = inspectCamera.transform.position;

            this.transform.position += inspectCamera.transform.forward * 3.0f;

            
            // enable inspect canvas and camera
        }
    }
}
