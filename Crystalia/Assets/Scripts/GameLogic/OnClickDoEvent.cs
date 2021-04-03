using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnClickDoEvent : MonoBehaviour {

    public List<UnityEvent> onClickDo;
    public bool mouseOver = false;
    private void OnMouseDown() {
        if (mouseOver && Input.GetMouseButtonDown(0))
            ClickMe();
    }
    private void OnMouseEnter() {
        EnterOnMe();
    }
    private void OnMouseExit() {
        ExitFromMe();
    }
    public void EnterOnMe() {
        mouseOver = true;
    }
    public void ExitFromMe() {
        mouseOver = false;
    }
    public void ClickMe() {
        for (int i = 0; i < onClickDo.Count; i++) {
            onClickDo[i].Invoke();
        }
    }
}