using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class InteractiveObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, ISubmitHandler, IExamineHandler, ISelectHandler, IDeselectHandler {

    GameObject _object;

    public bool activateOnClick;
    public bool activateOnTrigger;
    public bool canPickup;
    public bool canLoop;
    public Animation animation;
    public AudioClip[] audioActive;
    public AudioClip[] audioDenied;
    public string eventDispatch;
    public string eventTrigger;
    public string hoverText;
    public float resetTime;
    public string requiredItemName;

    private bool isActivated;
    private float timer;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (this.timer > 0) {
            this.timer -= Time.deltaTime;
        } else {
            this.timer = 0;
        }

        if (this.isActivated && this.canLoop && this.timer == 0) {
            ActivateObject();
        }
	}

    private void ActivateObject() {
        // check if disabled
        if (this.timer > 0)
            return;

        // set to activated
        this.isActivated = true;

        // check if does have item
        if (this.requiredItemName.Length > 0) {// && !Player.CheckHasItem(requiredItem)
            // play random denied clip
            if (this.audioDenied != null && this.audioDenied.Length > 0) {
                AudioClip randomClip = this.audioDenied[Random.Range(0, this.audioDenied.Length)];
                if (randomClip != null) {
                    AudioSource.PlayClipAtPoint(randomClip, this.transform.position);
                }
            }
            return;
        }
        
        // play audio
        if (this.audioActive != null && this.audioActive.Length > 0) {
            AudioClip randomClip = this.audioActive[Random.Range(0, this.audioActive.Length)];
            if (randomClip != null) {
                AudioSource.PlayClipAtPoint(randomClip, this.transform.position);
            }
        }
        
        // play animation
        if (this.animation != null) {
            this.animation.Play();
        }
        
        // trigger event
        if (this.eventDispatch != null && this.eventDispatch.Length > 0) {
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

    public void OnDeselect(BaseEventData eventData) {
    }

    void OnDisable() {
        // unregister listeners
        if (this.eventTrigger != null && this.eventTrigger.Length > 0)
            EventManager.StopListening(this.eventTrigger, OnTriggerEvent);
    }

    void OnEnable() {
        // register listeners
        if (this.eventTrigger != null && this.eventTrigger.Length > 0)
            EventManager.StartListening(this.eventTrigger, OnTriggerEvent);
    }

    public void OnExamine(PointerEventData eventData) {
        Debug.Log("I was examined wuuut!");

        // TODO this is a temporary version
        if (this.canPickup == true) {
            // find inventory
            Inventory playerInvetory = GameObject.Find("FPSController").GetComponent<Inventory>();

            // add to inventory
            playerInvetory.AddItem(name);

            // destroy object
            Destroy(this.gameObject);
        }
        // TODO end temporary version
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (this.activateOnClick)
            ActivateObject();
    }
    
    public void OnPointerEnter(PointerEventData eventData) {
        EventManager.TriggerEvent(GameEvent.HoverTextShow.ToString(), this.hoverText);
    }
    
    public void OnPointerExit(PointerEventData eventData) {
        EventManager.TriggerEvent(GameEvent.HoverTextHide.ToString());
    }

    public void OnSelect(BaseEventData eventData) {
    }

    public void OnSubmit(BaseEventData eventData) {
        Debug.Log("I was sumbitted?");
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

    public void OnTriggerEvent(object eventData) {
        ActivateObject();
    }




}
