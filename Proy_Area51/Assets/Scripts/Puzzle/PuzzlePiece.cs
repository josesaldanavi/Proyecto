﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

class PuzzlePiece : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
    }
}
