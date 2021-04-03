using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBigCard : MonoBehaviour {
    public static ShowBigCard instance;

    public Image generalCard, clashCard;
    private void Awake() {
        instance = this;
    }
    public void ShowGeneralCardInfo(Card currentCardToShow) {
        generalCard.enabled = true;
        generalCard.sprite = currentCardToShow.cardImage;
        //TODO: HUD con tutti i riferimenti e effetti
    }

    public void HideGeneralCardInfo() {
        generalCard.enabled = false;
    }
    public void ShowClashCardInfo(Card currentCardToShow) {
        clashCard.enabled = true;
        clashCard.sprite = currentCardToShow.cardImage;
        //TODO: HUD con tutti i riferimenti e effetti
    }

    public void HideClashCardInfo() {
        clashCard.enabled = false;
    }

}
