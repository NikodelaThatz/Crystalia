using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HandCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler {

    public bool onHand = true;
    public bool onClickPosition = false;

    public bool pgCard, spellCard, itemCard;
    public bool needPromotion = false;
    public Card.SummonRequisite requisite;
    bool mouseEnter = false;
    Transform originalParent;
    Vector3 originalPosition;
    int originalIndex;
    Vector3 originalScale;

    public int mycardID, myExpansionID;
    Image myImage;
    Card myReference;
    private void Awake() {
        originalParent = transform.parent;
        originalIndex = transform.GetSiblingIndex();
        originalScale = transform.localScale;
        originalPosition = transform.position;
        myImage = GetComponent<Image>();
    }

    private void Update() {
        //Referenze varia
        myReference = ListOfCards.instance.listOfExpansions[myExpansionID].cards[mycardID];
        requisite = myReference.summonRequisite;   

        //Carta in mano
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
            bool checkedPositionFree = false;
            bool checkedPositionFreeAsPromotion = false;
            var cv = CardDragVisualizer.instance;
            if (cv.mySlot != null) {
                if (cv.myCard.deckType == Card.DeckType.Deck && cv.mySlot.isPgSlot) {
                    //La carta è nello slot giusto
                    if (cv.mySlot.myCardSlot == null) {
                        //Lo slot è vuoto
                        if (cv.myCard.rank == Card.Rank.basic) {
                            //La carta è basic, posso piazzarla
                            checkedPositionFree = true;
                        }
                    } 
                    if (cv.mySlot.myCardSlot != null && GameManager.instance.promoting) {
                        //La zona non è vuota, però sto promuovendo. Controllo se posso promuovere.
                        if (cv.myCard.rank == Card.Rank.superior && cv.mySlot.myCardSlot.rank == Card.Rank.basic) {
                            //E' possibile promuovere questa carta da basic a superior
                            checkedPositionFreeAsPromotion = true;
                            //Invoke: promozione
                        }
                        if (cv.myCard.rank == Card.Rank.legendary && cv.mySlot.myCardSlot.rank == Card.Rank.superior) {
                            //E' possibile promuovere questa carta da superior a legendary
                            checkedPositionFreeAsPromotion = true;
                            //Invoke: promozione
                        }
                    }
                }
            } else {
                checkedPositionFreeAsPromotion = false;
                checkedPositionFree = false;
            }


            if (checkedPositionFree) {
                var prefab = Instantiate(GameManager.instance.cardPrefab, cv.mySlot.transform.position, Quaternion.identity);
                var newCard = prefab.GetComponent<CardHandler>();
                newCard.expansionID = myExpansionID;
                newCard.cardID = mycardID;
                cv.mySlot.myCardSlot = newCard.myCard;
                GameManager.instance.currentCardInMouse = null;
                Destroy(gameObject);
            }

            onClickPosition = false;


            if (!checkedPositionFree) {
                //Slot occupato, o è impossibile mettere questa carta nello slot per qualche ragione (richiede forse una promozione?)
                transform.parent = originalParent;
                transform.position = originalPosition;
                transform.SetSiblingIndex(originalIndex);
                GameManager.instance.currentCardInMouse = null;
            }

            CardDragVisualizer.instance.cardID = -1;
            CardDragVisualizer.instance.expansionID = -1;


        }
    }
}
