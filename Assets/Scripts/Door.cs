using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Door : MonoBehaviour, IExamineHandler {

    public float doorOpenAngle1;
    public float doorOpenAngle2;
    public AudioClip doorOpenSound;
    public AudioClip doorLockedSound;
    public float doorTimer = 3.0f;
    public bool isLocked = false;
    public float smooth = 2.0f;
    public Vector3 doorHinge;

    private float doorCloseAngle = 0.0f;
    private bool isOpen = false;
    private float targetAngle = 0.0f;
    private float timeLeft = 0.0f;

	// Use this for initialization
	void Start () {
        doorCloseAngle = transform.eulerAngles.y;
	}

	// Update is called once per frame
	void Update () {

        // update timer
        if (timeLeft > 0.0f) {
            timeLeft -= Time.deltaTime;
        } else {
            isOpen = false;
        }
            
        if (isOpen && (timeLeft > 0.0f)) {

            // reposition
            transform.position += (transform.rotation * doorHinge);

            // rotate
            //transform.rotation *= Quaternion.AngleAxis(targetAngle * Time.deltaTime, Vector3.up);
            Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);

            // move back
            transform.position -= (transform.rotation * doorHinge);

        } else {
            // reposition
            transform.position += (transform.rotation * doorHinge);

            // rotate
            //transform.rotation *= Quaternion.AngleAxis(doorCloseAngle * Time.deltaTime, Vector3.up);
            Quaternion targetRotation = Quaternion.Euler(0, doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);

            // move back
            transform.position -= (transform.rotation * doorHinge);
        }

	}

    /*
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(doorHinge, doorHinge + new Vector3(0.0f, 2.0f, 0.0f));
    }
    */

    public void OnExamine(PointerEventData eventData) {
        if (isOpen == false) {

            if (isLocked == false) {
                isOpen = true;
                timeLeft = doorTimer;

                // get forward vector
                Vector3 forwardVector = transform.forward;

                // get hit vector
                Vector3 hitVector = eventData.pointerCurrentRaycast.worldNormal;

                if (forwardVector.z * hitVector.z > 0.0f) {
                    targetAngle = doorCloseAngle + doorOpenAngle2;
                } else {
                    targetAngle = doorCloseAngle + doorOpenAngle1;
                }

                // play open audio
                PlayAudio(this.doorOpenSound);
            } else {
                // play locked audio
                PlayAudio(this.doorLockedSound);
            }
        }
    }

    private void PlayAudio(AudioClip audioClip) {
        if (audioClip != null) {
            AudioSource.PlayClipAtPoint(audioClip, this.transform.position);
        }
    }
}
