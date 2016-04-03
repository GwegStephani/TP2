using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class LookInputModule : BaseInputModule {

    private PointerEventData lookEventData;

    void Awake() {
        // hide cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

	public override void Process ()
    {

        // get look data
        PointerEventData lookEventData = GetLookPointerEventData();

        // trigger to object that it has been highlighted
        HandlePointerExitAndEnter(lookEventData, lookEventData.pointerCurrentRaycast.gameObject);

        if (Input.GetButtonDown("Fire1")) {
            ExecuteEvents.Execute(lookEventData.pointerCurrentRaycast.gameObject, lookEventData, ExecuteEvents.pointerClickHandler);
        }

        if (Input.GetButtonDown("Submit")) {
            ExecuteEvents.Execute(lookEventData.pointerCurrentRaycast.gameObject, lookEventData, ExecuteEvents.submitHandler);
        }

        // not sure about this <--------------------------
        if (Input.GetKeyDown("e")) {
            //ExecuteEvents.Execute(lookEventData.pointerCurrentRaycast.gameObject, new BaseEventData(EventSystem.current), "test");
            ExecuteEvents.ExecuteHierarchy(lookEventData.pointerCurrentRaycast.gameObject, new BaseEventData(EventSystem.current), ExecuteEvents.submitHandler);
        }

        // TODO next is to add custom event
        // not sure about this <--------------------------
        if (Input.GetKeyDown("f")) {
            ExecuteEvents.Execute(lookEventData.pointerCurrentRaycast.gameObject, lookEventData, ActionExecuteEvents.examineHandler);
        }


        if (eventSystem.currentSelectedGameObject)
            Debug.Log("---->> " + eventSystem.currentSelectedGameObject.ToString());

    }


    public PointerEventData GetLookPointerEventData() {
        Vector2 lookposition;

        // get center of screen
        lookposition.x = Screen.width/2;
        lookposition.y = Screen.height/2;

        // setup lookEventData
        if (lookEventData == null)
            lookEventData = new PointerEventData(eventSystem);
        lookEventData.Reset();
        lookEventData.delta = Vector2.zero;
        lookEventData.position = lookposition;
        lookEventData.scrollDelta = Vector2.zero;

        // TODO range or limit. or have it a variable

        // raycast
        eventSystem.RaycastAll(lookEventData, m_RaycastResultCache);

        // get first hit object
        lookEventData.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);

        //Debug.Log(lookEventData.pointerCurrentRaycast.gameObject.ToString());

        // clear the cache
        m_RaycastResultCache.Clear();


        return lookEventData;
    }

}
