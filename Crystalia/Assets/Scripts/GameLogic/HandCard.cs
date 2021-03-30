using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerUpHandler {

    public bool onHand = true;
    public bool onClickPosition = false;
    bool mouseEnter = false;
    Transform originalParent;
    Vector3 originalPosition;
    int originalIndex;
    Vector3 originalScale;
    private void Awake() {
        originalParent = transform.parent;
        originalIndex = transform.GetSiblingIndex();
        originalScale = transform.localScale;
    }
    public void OnPointerClick(PointerEventData eventData) {
        if (mouseEnter) {
            onClickPosition = true;
            GameManager.instance.currentCardInMouse = this;
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        mouseEnter = true;
        var scale = originalScale;
        scale.x *= 1.2f;
        scale.y *= 1.2f;
        transform.localScale = scale;
    }

    public void OnPointerExit(PointerEventData eventData) {
        mouseEnter = false;
        transform.localScale = originalScale;
    }

    public void OnPointerUp(PointerEventData eventData) {
        mouseEnter = false;
        //Debug, ritorna in mano
        transform.parent = originalParent;
        transform.SetSiblingIndex(originalIndex);

        //Controllare se è stata posizionata in una zona apposita
    }
}
