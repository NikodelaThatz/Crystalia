using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Mirror;
public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public HandCard currentCardInMouse;

    public bool isAndroidDevice, isWindowsDevice;

    public Transform canvasScreen;

    public GameObject cardPrefab;

    public bool promoting, canClash;

    public List<UnityEvent> clashSlow, clashNormal, clashFast;
    public List<CardHandler> currentPlayerCards, foesCards;
    public NetworkIdentity currentTurnPlayer;

    private void Awake() {
        instance = this;
        isAndroidDevice = Application.platform == RuntimePlatform.Android;
        isWindowsDevice = Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor;
    }


    public void StartClash() {
        
    
    }


}