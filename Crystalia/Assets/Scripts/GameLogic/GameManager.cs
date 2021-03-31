using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public HandCard currentCardInMouse;

    public bool isAndroidDevice, isWindowsDevice;

    public Transform canvasScreen;
    private void Awake() {
        instance = this;
        isAndroidDevice = Application.platform == RuntimePlatform.Android;
        isWindowsDevice = Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor;
    }

}