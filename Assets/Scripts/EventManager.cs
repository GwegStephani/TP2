using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {

    private Dictionary <string, UnityEvent> eventDictionary;
    private Dictionary <string, DataEvent> dataEventDictionary;

    private static EventManager eventManager;

    public static EventManager instance {
        get {
            if (!eventManager) {
                eventManager = FindObjectOfType (typeof (EventManager)) as EventManager;

                if (!eventManager) {
                    Debug.LogError("There needs to be one active EventManager script on a GameObject in your scene.");
                }
                else {
                    eventManager.Initialize();
                }
            }

            return eventManager;
        }
    }

    void Initialize() {
        if (eventDictionary == null) {
            eventDictionary = new Dictionary<string, UnityEvent>();
        }

        if (dataEventDictionary == null) {
            dataEventDictionary = new Dictionary<string, DataEvent>();
        }
    }

    public static void StartListening(string eventName, UnityAction listener) {
        UnityEvent thisEvent = null;

        // try and find entry otherwise add it to the dictionary
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.AddListener(listener);
        }
        else {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StartListening(string eventName, UnityAction<object> listener) {
        DataEvent thisEvent = null;

        // try and find entry otherwise add it to the dictionary
        if (instance.dataEventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.AddListener(listener);
        }
        else {
            thisEvent = new DataEvent();
            thisEvent.AddListener(listener);
            instance.dataEventDictionary.Add(eventName, thisEvent);
        }

    }

    public static void StopListening(string eventName, UnityAction listener) {
        if (eventManager == null) return;

        UnityEvent thisEvent = null;

        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void StopListening(string eventName, UnityAction<object> listener) {
        if (eventManager == null) return;

        DataEvent thisEvent = null;

        if (instance.dataEventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.RemoveListener(listener);
        }

    }

    public static void TriggerEvent(string eventName) {
        UnityEvent unitysEvent = null;
        DataEvent dataEvent = null;

        if (instance.eventDictionary.TryGetValue(eventName, out unitysEvent)) {
            unitysEvent.Invoke();
        }
        if (instance.dataEventDictionary.TryGetValue(eventName, out dataEvent)) {
            dataEvent.Invoke(null);
        }

    }

    public static void TriggerEvent(string eventName, object data) {
        UnityEvent unitysEvent = null;
        DataEvent dataEvent = null;

        if (instance.eventDictionary.TryGetValue(eventName, out unitysEvent)) {
            unitysEvent.Invoke();
        }
        if (instance.dataEventDictionary.TryGetValue(eventName, out dataEvent)) {
            dataEvent.Invoke(data);
        }

    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

// custom event class to allow data to be passed with it
public class DataEvent : UnityEvent<object> {}
