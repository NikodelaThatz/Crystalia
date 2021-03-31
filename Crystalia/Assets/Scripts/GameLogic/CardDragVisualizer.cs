using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDragVisualizer : MonoBehaviour {

    public bool pgCard, itemCard, spellCard;
    public int cardID = -1, expansionID = 0 ;
    public SpriteRenderer sprite;
    public static CardDragVisualizer instance;
    // Start is called before the first frame update
    Vector3 originalAngle;
    void Awake() {
        instance = this;
        originalAngle = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update() {
        if (cardID != -1) {
            var myList = ListOfCards.instance;
            var myCard = myList.listOfExpansions[expansionID].cards[cardID];
            sprite.sprite = myCard.cardImage;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) {
                Transform objectHit = hit.transform;
                if (hit.collider == null) {
                    transform.position = hit.point;
                    transform.LookAt(Camera.main.transform.position, Vector3.up);
                } else {
                    var point = hit.point;
                    point.z -= 0.5f;
                    transform.position = point;
                    switch (hit.collider.tag) {
                        case "PgSlot":
                            if (pgCard) {
                                point = hit.collider.transform.position;
                                point.z -= 0.5f;
                                transform.position = point;
                            }
                            break;
                        case "ItemSlot":
                            if (itemCard) {
                                point = hit.collider.transform.position;
                                point.z -= 0.5f;
                                transform.position = point;
                            }
                            break;
                        case "SpellSlot":
                            if (spellCard) {
                                point = hit.collider.transform.position;
                                point.z -= 0.5f;
                                transform.position = point;

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
