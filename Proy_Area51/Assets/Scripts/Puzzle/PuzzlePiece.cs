using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

class PuzzlePiece : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //transform.localPosition = eventData.position;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
    	//transform.position = eventData.position;
    }

}

