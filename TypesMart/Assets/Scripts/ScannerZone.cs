using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerZone : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        Belt.instance.StopMoving();
    }

    private void OnTriggerStay2D(Collider2D collision) {
        Belt.instance.StopMoving();
    }

    private void OnTriggerExit2D(Collider2D collision) {
        Belt.instance.StartMoving();
    }
}
