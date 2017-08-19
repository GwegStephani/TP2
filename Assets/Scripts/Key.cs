using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Key : MonoBehaviour, IExamineHandler {


    public AudioClip getKeySound;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update ()
    {
    }

    public void OnExamine(PointerEventData eventData) {
       PlayAudio(this.getKeySound);
    }

    private void PlayAudio(AudioClip audioClip) {
        if (audioClip != null) {
            AudioSource.PlayClipAtPoint(audioClip, this.transform.position);
        }
    }
}