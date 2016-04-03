using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class InteractiveObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, ISubmitHandler, IExamineHandler {

    GameObject _object;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

    public void WhoHash(string test, Object obj) {
        Debug.Log("who hashed " + test);
    }

    public void OnPointerClick(PointerEventData eventData) {
        Debug.Log("I was mouse clicked");
        EventManager.TriggerEvent("test", new Vector3(25.0f, 69.69f, -122.21f));
    }

    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("I was mouse entered");
    }

    public void OnPointerExit(PointerEventData eventData) {
        Debug.Log("I was mouse exited");
    }

    public void OnSubmit(BaseEventData eventData) {
        Debug.Log("I was sumbitted?");
    }

    public void OnExamine(PointerEventData eventData) {
        Debug.Log("I was examined wuuut!");
    }


}
