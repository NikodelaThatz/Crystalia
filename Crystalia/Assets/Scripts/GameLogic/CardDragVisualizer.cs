using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDragVisualizer : MonoBehaviour {
    public static CardDragVisualizer instance;
    public bool pgCard, itemCard, spellCard;
    public int cardID = -1, expansionID = 0 ;
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    Vector3 originalAngle;
    public Card myCard;
    public BoardSlot mySlot;
    void Awake() {
        instance = this;
        originalAngle = transform.eulerAngles;

    }

    // Update is called once per frame
    void Update() {
        if (cardID != -1) {
            myCard = ListOfCards.instance.listOfExpansions[expansionID].cards[cardID];
            var myList = ListOfCards.instance;
       
            sprite.sprite = myCard.cardImage;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) {
                Transform objectHit = hit.transform;
                if (hit.collider == null) {
                    transform.position = hit.point;
                    transform.LookAt(Camera.main.transform.position, Vector3.up);
                } else {
                    transform.LookAt(Camera.main.transform.position, Vector3.up);
                    var point = hit.point;
                    point.z -= 0.5f;
                    transform.position = point;

                    if (hit.collider.tag != "PgSlot" || hit.collider.tag != "ItemSlot" || hit.collider.tag != "SpellSlot") {
                        mySlot = null;
                    }

                    switch (hit.collider.tag) {
                        case "PgSlot":
                            mySlot = null;
                            if (pgCard) {
                                transform.eulerAngles = originalAngle;
                                point = hit.collider.transform.position;
                                point.z -= 0.5f;
                                transform.position = point;
                                mySlot = hit.collider.GetComponent<BoardSlot>();
                            }
                            break;
                        case "ItemSlot":
                            mySlot = null;
                            if (itemCard) {
                                transform.eulerAngles = originalAngle;
                                point = hit.collider.transform.position;
                                point.z -= 0.5f;
                                transform.position = point;
                                mySlot = hit.collider.GetComponent<BoardSlot>();
                            }
                            break;
                        case "SpellSlot":
                            mySlot = null;
                            if (spellCard) {
                                transform.eulerAngles = originalAngle;
                                point = hit.collider.transform.position;
                                point.z -= 0.5f;
                                transform.position = point;
                                mySlot = hit.collider.GetComponent<BoardSlot>();

                            }
                            break;
                    }
                    transform.eulerAngles = originalAngle;
                }
                
            }
        
        } else {
            sprite.sprite = null;
        }
        
    }

}
