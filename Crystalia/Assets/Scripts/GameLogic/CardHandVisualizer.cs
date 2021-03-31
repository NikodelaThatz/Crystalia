using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardHandVisualizer : MonoBehaviour {
    public HorizontalLayoutGroup panel;
    public List<Image> myCards;
    public static CardHandVisualizer instance;

    public void Awake() {
        instance = this;
    }
}