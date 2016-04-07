using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class InteractiveObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, ISubmitHandler, IExamineHandler {

    GameObject _object;

    public bool activateOnClick;
    public bool activateOnTrigger;
    public Animation animation;
    public AudioClip audioActive;
    public AudioClip audioDenied;
    public GameEvent eventDispatch;
    public GameEvent eventTrigger;
    public string hoverText;
    public float resetTime;
    public string requiredItem;

    private float timer;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (this.resetTime > 0) {
            this.timer -= Time.deltaTime;
        }
        else {
            this.timer = 0;
        }


	}

    private void ActivateObject() {
        // check if disabled
        if (this.timer > 0)
            return;

        // check if does have item
        if (this.requiredItem.Length > 0) {// && !Player.CheckHasItem(requiredItem)
            
            if (this.audioDenied != null)
                AudioSource.PlayClipAtPoint(this.audioDenied, this.transform.position);
            return;
        }
        
        // play audio
        if (this.audioActive != null)
            AudioSource.PlayClipAtPoint(this.audioActive, this.transform.position);
        
        // play animation
        if (this.animation != null) {
            this.animation.Play();
        }
        
        // trigger event
        if (this.eventDispatch != null && this.eventDispatch != GameEvent.None) {
            EventManager.TriggerEvent(this.eventDispatch);
        }
        
        // start reset timer
        if (this.resetTime > 0) {
            this.timer = this.resetTime;
        }
    }


    void OnCollisionEnter(Collision collisionInfo) {
        Debug.Log("I am OnCollisionEnter()");
    }

    void OnCollisionExit(Collision collisionInfo) {
        Debug.Log("I am OnCollisionExit()");
    }

    void OnCollisionStay(Collision collisionInfo) {
        Debug.Log("I am OnCollisionStay()");
    }

    void OnEnable() {
        // register listeners
        if (this.eventTrigger != null && this.eventTrigger != GameEvent.None)
            EventManager.StartListening(this.eventTrigger, OnTriggerEvent);
    }


    void OnDisable() {
        // unregister listeners
        if (this.eventTrigger != null && this.eventTrigger != GameEvent.None)
            EventManager.StopListening(this.eventTrigger, OnTriggerEvent);
    }

    void OnTriggerEnter(Collider other) {
        // TODO need to add in what type to trigger on. by tag, name, player, etc
        if (this.activateOnTrigger)
            ActivateObject();
    }

    void OnTriggerExit(Collider other) {
    }

    void OnTriggerStay(Collider other) {
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (this.activateOnClick)
            ActivateObject();
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

    public void OnTriggerEvent(object eventData) {
        ActivateObject();
    }




}
