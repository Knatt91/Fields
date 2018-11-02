using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public Transform parentToReturnTo = null;

    public enum CardType { INFANTRY, TERRAIN, ITEM }
    public CardType typeOfCard = CardType.INFANTRY;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");

        //when the drag starts the card will set 'parentToReturnTo' to it's current parent
        //If the card is dragged to a spot that is invaled, then the card will default to its origional parent
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);

        //Turns off raycasts in order for the mouse to know what zone its over. 
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");

        this.transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");

        this.transform.SetParent(parentToReturnTo);

        //when the player releases click and drag of card, then its blockRaycasts will be turned back on.
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

}
