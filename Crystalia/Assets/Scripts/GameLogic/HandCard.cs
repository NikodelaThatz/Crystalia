using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HandCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler {

    public bool onHand = true;
    public bool onClickPosition = false;

    public bool pgCard, spellCard, itemCard;

    bool mouseEnter = false;
    Transform originalParent;
    Vector3 originalPosition;
    int originalIndex;
    Vector3 originalScale;

    public int mycardID, myExpansionID;
    Image myImage;
    private void Awake() {
        originalParent = transform.parent;
        originalIndex = transform.GetSiblingIndex();
        originalScale = transform.localScale;
        originalPosition = transform.position;
        myImage = GetComponent<Image>();
    }

    private void Update() {
        if (onClickPosition) {
            myImage.enabled = false;
        } else {
            var myList = ListOfCards.instance;
            var myCard = myList.listOfExpansions[myExpansionID].cards[mycardID];
            myImage.sprite = myCard.cardImage;
            myImage.enabled = true;
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        if (GameManager.instance.isAndroidDevice && !mouseEnter) {
            var all = FindObjectsOfType<HandCard>();
            for (int i = 0; i < all.Length; i++) {
                all[i].ExitFromMe();
            }
            EnterOnMe();
            return;
        }
        if (mouseEnter) {
            if (GameManager.instance.currentCardInMouse == null) {
                onClickPosition = true;
                GameManager.instance.currentCardInMouse = this;
                transform.parent = GameManager.instance.canvasScreen;
                CardDragVisualizer.instance.cardID = mycardID;
                CardDragVisualizer.instance.expansionID = myExpansionID;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (!GameManager.instance.isWindowsDevice)
            return;
        EnterOnMe();
    }

    public void EnterOnMe() {
       
        if (GameManager.instance.currentCardInMouse == null && !onClickPosition) {
            mouseEnter = true;
            var scale = originalScale;
            scale.x *= 1.2f;
            scale.y *= 1.2f;
            transform.localScale = scale;
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        ExitFromMe();
    }
    public void ExitFromMe() {
        if (!onClickPosition) {
            mouseEnter = false;
            transform.localScale = originalScale;
        }

    }
    public void OnPointerUp(PointerEventData eventData) {
        PointerUp();

    }
    public void PointerUp() {
        if (onClickPosition) {
            //mouseEnter = false;
            //Debug, ritorna in mano
            onClickPosition = false;
            transform.parent = originalParent;
            transform.position = originalPosition;
            transform.SetSiblingIndex(originalIndex);
            GameManager.instance.currentCardInMouse = null;
            CardDragVisualizer.instance.cardID = -1;
            CardDragVisualizer.instance.expansionID = -1;
            //Controllare se è stata posizionata in una zona apposita
        }
    }
}
