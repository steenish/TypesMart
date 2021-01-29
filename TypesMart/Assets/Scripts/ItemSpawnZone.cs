using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnZone : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {
        Belt.instance.StopSpawning();
    }

    private void OnTriggerStay2D(Collider2D collision) {
        Belt.instance.StopSpawning();
    }

    private void OnTriggerExit2D(Collider2D collision) {
        Belt.instance.StartSpawning();
    }
}
