using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class InteractiveObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, ISubmitHandler, IExamineHandler {

    GameObject _object;

    public Animation animation;
    public AudioClip audioActive;
    public AudioClip audioDenied;
    public GameEvent eventDispath;
    public GameEvent eventTrigger;
    public string hoverText;
    public float resetTime;
    public string requiredItem;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void OnPointerClick(PointerEventData eventData) {
        Debug.Log("I was mouse clicked");
        EventManager.TriggerEvent(GameEvent.Test, new Vector3(25.0f, 69.69f, -122.21f));

        // check if does have item
        if (this.requiredItem.Length > 0) {// && !Player.CheckHasItem(requiredItem)

            if (this.audioDenied != null)
                AudioSource.PlayClipAtPoint(this.audioDenied, this.transform.position);
            return;
        }



        // play audio
        if (this.audioActive != null)
            AudioSource.PlayClipAtPoint(this.audioDenied, this.transform.position);

        // play animation

        // trigger event
        if (this.eventDispath != null && this.eventDispath != GameEvent.None) {
            EventManager.TriggerEvent(this.eventDispath);
        }

        // start reset timer
        if (this.resetTime > 0) {

        }


    }

    public void OnPointerEnter(PointerEventData eventData) {
        EventManager.TriggerEvent(GameEvent.HoverTextShow, this.hoverText);
    }

    public void OnPointerExit(PointerEventData eventData) {
        EventManager.TriggerEvent(GameEvent.HoverTextHide);
    }

    public void OnSubmit(BaseEventData eventData) {
        Debug.Log("I was sumbitted?");
    }

    public void OnExamine(PointerEventData eventData) {
        Debug.Log("I was examined wuuut!");
    }

    public void OnTriggerEvent(BaseEventData eventData) {
        OnPointerClick(null);
    }


}
