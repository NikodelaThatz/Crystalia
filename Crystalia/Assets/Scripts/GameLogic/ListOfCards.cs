using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfCards : MonoBehaviour {
    [System.Serializable]
    public class ListOfExpansions {
        public List<Card> cards;
    }

    public static ListOfCards instance;

    public List<ListOfExpansions> listOfEpansions;

    private void Awake() {
        instance = this;

    }
}