using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardHandVisualizer : MonoBehaviour {
    public VerticalLayoutGroup panel;
    public List<Image> myCards;
    public static CardHandVisualizer instance;
    float originalSpacing;
    [Range(-4000, 0)]
    public float minSpacing, maxSpacing;
    public void Awake() {
        instance = this;
        originalSpacing = panel.spacing;
    }

    private void Update() {
        CheckHand();
    }

    void CheckHand() {
        panel.spacing = originalSpacing - (panel.transform.childCount * 100);
        if (panel.spacing > maxSpacing) {
            panel.spacing = maxSpacing;
        }
        if (panel.spacing < minSpacing) {
            panel.spacing = minSpacing;
        }
    }
}