using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    private Dictionary<KeyCode, char> alphabet;
    private Item currentItem { 
        get {
            return Belt.instance.currentItem;
        }
    }

    void Start() {
        InitializeAlphabet();
    }

    void OnGUI() {
        Event e = Event.current;
        
        if (e.isKey && e.type == EventType.KeyDown && e.keyCode != KeyCode.None) {
            try {
                if (currentItem.SendCharacter(alphabet[e.keyCode])) {
                    Belt.instance.CheckOutItem();
                }
            } catch {
                Debug.Log("strange key pressed");
            }
        }
    }

    void InitializeAlphabet() {
        alphabet = new Dictionary<KeyCode, char>();
        alphabet.Add(KeyCode.Space, '_');

        KeyCode[] keyCodes = (KeyCode[]) Enum.GetValues(typeof(KeyCode));

        foreach (KeyCode code in keyCodes) {
            string keyString = code.ToString().ToLower();
            if (keyString.Length == 1) {
                alphabet.Add(code, keyString[0]);
            }
        }
    }
}
