using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public static class ActionExecuteEvents {

    private static void Execute(IExamineHandler handler, BaseEventData eventData) {
        handler.OnExamine(ExecuteEvents.ValidateEventData<PointerEventData> (eventData));
    }

    public static ExecuteEvents.EventFunction<IExamineHandler> examineHandler {
        get { return Execute; }
    }

}
