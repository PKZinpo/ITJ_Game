using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPresses : MonoBehaviour {

    public Text move;
    public Text jump;

    private bool fadeKeysIn = false;
    private bool fadeKeysOut = false;

    void Start() {
        var color = GetComponent<SpriteRenderer>().color;
        var colorMove = move.GetComponent<Text>().color;
        var colorJump = jump.GetComponent<Text>().color;

        color.a = 0f;
        colorMove.a = 0f;
        colorJump.a = 0f;

        GetComponent<SpriteRenderer>().color = color;
        move.GetComponent<Text>().color = colorMove;
        jump.GetComponent<Text>().color = colorJump;

        Invoke("FadeKeysIn", 2f);
    }

    void Update() {
        var color = GetComponent<SpriteRenderer>().color;
        var colorMove = move.GetComponent<Text>().color;
        var colorJump = jump.GetComponent<Text>().color;
        if (fadeKeysIn && fadeKeysOut) {
            if (color.a > 0) {
                color.a -= 0.01f;
                colorMove.a -= 0.01f;
                colorJump.a -= 0.01f;

                GetComponent<SpriteRenderer>().color = color;
                move.GetComponent<Text>().color = colorMove;
                jump.GetComponent<Text>().color = colorJump;
            }
        }
        else if (fadeKeysIn) {
            if (color.a < 1) {
                color.a += 0.01f;
                colorMove.a += 0.01f;
                colorJump.a += 0.01f;

                GetComponent<SpriteRenderer>().color = color;
                move.GetComponent<Text>().color = colorMove;
                jump.GetComponent<Text>().color = colorJump;
            }
        }
    }

    public void FadeKeysIn() {
        fadeKeysIn = true;
        Invoke("FadeKeysOut", 3f);
    }
    public void FadeKeysOut() {
        fadeKeysOut = true;
    }
}
