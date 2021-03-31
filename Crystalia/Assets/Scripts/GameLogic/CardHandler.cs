using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CardHandler : MonoBehaviour {

    public Card myCard;
    //L'identificatore della carta
    public int cardID = 0;
    //L'identificatore dell'espansione della carta
    public int expansionID = 0;

    //Lo sprite frontale della carta, l'immagine di tutto.
    public SpriteRenderer frontSprite;
    //La carta è sul campo o sulla mano?
    public bool placed = false, inHand = false;

    [HideInInspector]
    public NetworkIdentity myNetId, ownerNetId;
    private void Awake() {
        SetUp();
    }

    void SetUp() {
        //Setup della carta
        frontSprite.sprite = myCard.cardImage;

        //Trova se stessa nella lista di carte complete
        var myList = ListOfCards.instance;
        if (myList == null)
            return;
        for (int i = 0; i < myList.listOfExpansions.Count; i++) {
            for (int ii = 0; ii < myList.listOfExpansions[i].cards.Count; ii++) {
                if (myList.listOfExpansions[i].cards[ii] == myCard) {
                    cardID = ii;
                    expansionID = i;
                    break;
                }
            }
        }
    }

    void OnHand() {
        
    }
}