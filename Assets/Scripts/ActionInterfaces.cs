using System;
using UnityEngine.EventSystems;


public interface IExamineHandler : IEventSystemHandler {
    void OnExamine(PointerEventData eventData);
}