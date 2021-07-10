using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideable : MonoBehaviour {

    public GameObject text;
    public GameObject player;
    public Transform bottomLeft;
    public Transform topRight;
    public LayerMask whatIsPlayer;

    [SerializeField] private Vector3 textOffset;
    private bool showText = false;
    private bool isTouching = false;

    void Update() {

        isTouching = Physics2D.OverlapArea(bottomLeft.transform.position, topRight.transform.position, whatIsPlayer);

        if (isTouching) {
            if (!showText) {
                ShowFloatingText();
                showText = true;
            }
            if (Input.GetKeyDown(KeyCode.E)) {
                PlayerMovement.isHiding = !PlayerMovement.isHiding;
                if (PlayerMovement.isHiding) {
                    var color = player.GetComponent<SpriteRenderer>().color;
                    color.a = 0;
                    player.GetComponent<SpriteRenderer>().color = color;
                    player.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
                }
                else {
                    var color = player.GetComponent<SpriteRenderer>().color;
                    color.a = 1;
                    player.GetComponent<SpriteRenderer>().color = color;
                }
            }
        }
        else {
            if (GameObject.FindGameObjectsWithTag("Text").Length != 0) {
                foreach (var item in GameObject.FindGameObjectsWithTag("Text")) {
                    Destroy(item);
                    showText = false;
                }
            }
        }

    }

    void ShowFloatingText() {
        GameObject textObject = Instantiate(text, transform.position, Quaternion.identity, transform);
        textObject.GetComponent<TextMesh>().text = "Press E to Hide";
        textObject.transform.localPosition += textOffset;
    }
}
