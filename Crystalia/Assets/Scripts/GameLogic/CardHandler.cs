using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CardHandler : MonoBehaviour {

    public Card myCard;

    public List<Card> soulCards = new List<Card>();

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
    private void Update() {
        SetUp();
    }
    void SetUp() {
        //Setup della carta
        myCard = ListOfCards.instance.listOfExpansions[expansionID].cards[cardID];
        frontSprite.sprite = myCard.cardImage;
    }

    void OnHand() {
        
    }
}