using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSlot : MonoBehaviour {
    //La carta che ho ora sopra di me
    public Card myCardSlot;

    public bool isPgSlot, isItemSlot, isSpellSlot, crystalSlot;

    public int slotId;

    public BoardSlot inFrontOfMe, behindMe;

    public List<GameObject> myCardsOnTop;

}