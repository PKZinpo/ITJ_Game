using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoInitial : MonoBehaviour {

    public Collider2D colliderInitial;
    public GameObject player;

    void Start() {
        Invoke("StartDialogue", 1f);
    }
    public void StartDialogue() {
        colliderInitial.enabled = true;
    }
    public void OnTriggerEnter2D(Collider2D collision) {
        colliderInitial.enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
