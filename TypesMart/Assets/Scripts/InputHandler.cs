using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    public Item currentItem;

    private Dictionary<KeyCode, char> alphabet;

    void Start() {
        InitializeAlphabet();
    }

    void OnGUI() {
        Event e = Event.current;
        
        if (e.isKey
            && e.type == EventType.KeyDown
            && e.keyCode != KeyCode.None &&
            currentItem.SendCharacter(alphabet[e.keyCode])) {
            
            Destroy(currentItem.gameObject);
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
