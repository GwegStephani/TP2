﻿using UnityEngine;
using System.Collections;

public class Reticle : MonoBehaviour {

    private Ray ray;
    private RaycastHit hitInfo;

    public Texture2D image;
    public float maxDistance = 20f;

    Rect position;

	// Use this for initialization
	void Start () {

        // hide cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // get the center of the screen
        if (image != null) {
            position = new Rect((Screen.width - image.width) / 2, (Screen.height - image.height) / 2, image.width, image.height);
        }

	}
	
	// Update is called once per frame
	void Update () {

        // update ray
        ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out hitInfo, maxDistance)) {

            if (Input.GetButtonDown("Fire1")) {
                //Debug.Log("I was clicked");
                if (hitInfo.rigidbody)
                    hitInfo.rigidbody.AddForce(Camera.main.transform.forward * 1000f);
                
                hitInfo.collider.SendMessage("Clicked", Globals.MouseClicked);



                // test code
                //ExamineObject examObjectScript = GetComponent<ExamineObject>();
                
                //examObjectScript.Trigger(hitInfo.collider.gameObject);
                // end of test code

                
            }
        }

        // escape button
        if (Input.GetButtonDown("Cancel")) {
            Debug.Log("snake...escapeded!");
        }

	}

    void Clicked(string option) {
        Debug.Log("i was clicked with: " + option);

    }

    void OnGUI() {
        // draw recticle image
        if (image != null) {
            GUI.DrawTexture(position, image);
        }

        // reticle hit something
        if (hitInfo.collider) {
            hitInfo.collider.SendMessage("Hover");
        }


    }

	void OnMouseUpAsButton() {

	}

    void OnCollisionEnter(Collision colider) {
        Debug.Log("Collided!!!");
    }


}
