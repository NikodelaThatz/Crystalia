using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DeckLogic : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler {

    public static DeckLogic deckInstance, tavernDeckInstance, bazaarDeckInstance;

    public enum DeckType {
        Deck, Tavern, Bazaar
    }
    public DeckType deckType;
    public int maxCards = 50;
    public int currentCards = 50;
    public GameObject deckFolder;

    public List<Card> myCards;
    private void Awake() {
        switch (deckType) {
            case DeckType.Deck:
                deckInstance = this;
                break;
            case DeckType.Tavern:
                tavernDeckInstance = this;
                break;
            case DeckType.Bazaar:
                bazaarDeckInstance = this;
                break;
        }
    }
    private void Start() {
        //Debug
        currentCards = 0;
        Invoke("AddRandomCard", 0.25f);
        //
        ShuffleDeck();
    }

    private void Update() {
        if (currentCards <= 0 && deckFolder.activeSelf) {
            deckFolder.SetActive(false);
            if (deckType == DeckType.Deck) {
                //Sconfitta.
            }
        }
        if (currentCards > 0 && !deckFolder.activeSelf) {
            deckFolder.SetActive(true);
        }
        //Debug, mischia il mazzo se premo spazio
        if (Input.GetKeyDown(KeyCode.Space)) {
            ShuffleDeck();
        }
    }

    void AddRandomCard() {
        //Usato per il debug, ottengo in modo casuale tutte le carte dall'espansione e le aggiungo alle mie, ripeto fino a che non sono al massimo
        myCards.Add(ListOfCards.instance.listOfExpansions[0].cards[Random.Range(0, ListOfCards.instance.listOfExpansions[0].cards.Count)]);
        currentCards++;

        if (currentCards < maxCards) {
            Invoke("AddRandomCard", 0.25f);
        }
    }

    public void ShuffleDeck() {
        for (int i = 0; i < myCards.Count; i++) {
            var temp = myCards[i];
            int randomIndex = Random.Range(i, myCards.Count);
            myCards[i] = myCards[randomIndex];
            myCards[randomIndex] = temp;
        }
    }


    void DeckScaler() {
        var scale = deckFolder.transform.localScale;
        scale.z = (float)currentCards / maxCards;
        deckFolder.transform.localScale = scale;
    }


    public void OnPointerDown(PointerEventData eventData) {

    }

    public void OnPointerEnter(PointerEventData eventData) {

    }

    public void EnterOnMe() {

    }

    public void OnPointerExit(PointerEventData eventData) {
        ExitFromMe();
    }
    public void ExitFromMe() {


    }
    public void OnPointerUp(PointerEventData eventData) {
        PointerUp();

    }

    public void PointerUp() {

    }

}