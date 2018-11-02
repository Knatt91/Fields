using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler {

    public enum ZoneType { P1HOMEFRONT, P1BATTLEFIELD, P1HFTERRAIN, P1BFTERRAIN, P2HOMEFRONT, P2BATTLEFIELD, P2HFTERRAIN, P2BFTERRAIN }
    //public enum CardType { INFANTRY, TERRAIN, ITEM }
    public ZoneType typeOfZone = ZoneType.P1HOMEFRONT;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            //if the card is of type INFANTRY than it can be dropped in "P1HOMEFRONT" type zone
            if (d.typeOfCard == Draggable.CardType.INFANTRY && typeOfZone == ZoneType.P1HOMEFRONT)
            {
                d.parentToReturnTo = this.transform;
            }
            //if the card is of type TERRAIN than it can be dropped in any terrain type zone
            if (d.typeOfCard == Draggable.CardType.TERRAIN && typeOfZone == ZoneType.P1HFTERRAIN || typeOfZone == ZoneType.P1BFTERRAIN || typeOfZone == ZoneType.P2BFTERRAIN || typeOfZone == ZoneType.P2HFTERRAIN)
            {
                d.parentToReturnTo = this.transform;
            }
        }
    }
}
