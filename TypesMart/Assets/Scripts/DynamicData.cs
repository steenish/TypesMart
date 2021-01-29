using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class DynamicData : MonoBehaviour {

    public GameObject itemPrefab;

    public static DynamicData instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
    }
}
