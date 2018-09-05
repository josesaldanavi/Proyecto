using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Piece : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    
	public Puzzle rootParent;
    public Transform previousParent;
	public int id;
   
	
	public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin");
        if (transform.parent != rootParent.transform)
        {
            Debug.Log("Parent isn't root");
            previousParent = transform.parent;
            transform.SetParent(rootParent.transform);

        }
        else
        {
            previousParent = null;
        }

		
		transform.SetAsLastSibling();
		//GetComponent<Image>().raycastTarget = false;
        BlockPiecesfromRaycast();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Ongoing");
		transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End");
		GameObject checkTarget = eventData.pointerCurrentRaycast.gameObject;
		if (checkTarget) {
            if(checkTarget.CompareTag("Slot")){
                if (checkTarget.transform.childCount != 0 && previousParent)
                {
                    SwapHoveredPiece(checkTarget);
                    SnapThis(checkTarget);
                }
                else if ((checkTarget.transform.childCount == 0))
                {
                    SnapThis(checkTarget);
                }


                //SnapThis(checkTarget);

                rootParent.CheckCompletion();
            }

        }
        else
        {
            SnapToPreviousParent();
        }
        AllowPiecesfromRaycast();
		//GetComponent<Image>().raycastTarget = true;
    }

    private void BlockPiecesfromRaycast()
    {
        int arrayLength=rootParent.pieces.Length;
        for (int i = 0; i < arrayLength; i++)
        {
            rootParent.pieces[i].GetComponent<Image>().raycastTarget = false;
        }
    }

    private void AllowPiecesfromRaycast()
    {
        int arrayLength = rootParent.pieces.Length;
        for (int i = 0; i < arrayLength; i++)
        {
            rootParent.pieces[i].GetComponent<Image>().raycastTarget = true;
        }
    }

    private void SnapThis(GameObject checkTarget)
    {
        transform.SetParent(checkTarget.transform);
        transform.localPosition = Vector3.zero;
    }

    private void SnapToPreviousParent()
    {
        transform.SetParent(previousParent);
        transform.localPosition = Vector3.zero;
    }

    private void SwapHoveredPiece(GameObject checkTarget)
    {
        Transform pieceToSwap = checkTarget.transform.GetChild(0);
        pieceToSwap.SetParent(previousParent.transform);
        pieceToSwap.localPosition = Vector3.zero;
    }
}
