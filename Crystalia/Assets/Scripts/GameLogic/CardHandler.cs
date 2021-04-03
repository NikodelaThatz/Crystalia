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

    public OnClickDoEvent soulSlashEffect, releaseEffect, prepareToAttack, effect, discard;

    public bool isAttacking;

    public bool active;
    private void Awake() {
        SetUp();
    }
    private void Update() {
        SetUp();
        CheckClickable();
    }
    void SetUp() {
        //Setup della carta
        myCard = ListOfCards.instance.listOfExpansions[expansionID].cards[cardID];
        frontSprite.sprite = myCard.cardImage;
    }
    void CheckClickable() {
        soulSlashEffect.gameObject.SetActive(myCard.soulsSlashEffect != Card.SoulsSlashEffect.None && active);
        releaseEffect.gameObject.SetActive(myCard.releaseEffect != Card.Release.None && active);
        effect.gameObject.SetActive(active);
        prepareToAttack.gameObject.SetActive(active);
        discard.gameObject.SetActive(active);
    }
    void OnHand() {
        
    }

    public void ShowMyBigCard() {
        ShowBigCard.instance.ShowGeneralCardInfo(myCard);
        Invoke("Hide", 2f);
    }

    void Hide() {
        ShowBigCard.instance.HideGeneralCardInfo();
    }
}