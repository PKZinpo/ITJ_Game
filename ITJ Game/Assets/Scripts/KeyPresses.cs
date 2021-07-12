using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyPresses : MonoBehaviour {

    public Text move;
    public Text jump;

    private bool fadeKeysIn = false;
    private bool fadeKeysOut = false;
    private Color colorJump;

    void Start() {
        var color = GetComponent<SpriteRenderer>().color;
        var colorMove = move.GetComponent<Text>().color;
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Level1") {
            colorJump = jump.GetComponent<Text>().color;
            colorJump.a = 0f;
            jump.GetComponent<Text>().color = colorJump;
        }
        

        color.a = 0f;
        colorMove.a = 0f;

        GetComponent<SpriteRenderer>().color = color;
        move.GetComponent<Text>().color = colorMove;

        Invoke("FadeKeysIn", 2f);
    }

    void Update() {
        Scene scene = SceneManager.GetActiveScene();
        var color = GetComponent<SpriteRenderer>().color;
        var colorMove = move.GetComponent<Text>().color;
        if (scene.name == "Level1") {
            colorJump = jump.GetComponent<Text>().color;
        }
        if (fadeKeysIn && fadeKeysOut) {
            if (color.a > 0) {
                color.a -= 0.01f;
                colorMove.a -= 0.01f;
                if (scene.name == "Level1") {
                    colorJump.a -= 0.01f;
                }

                GetComponent<SpriteRenderer>().color = color;
                move.GetComponent<Text>().color = colorMove;
                if (scene.name == "Level1") {
                    jump.GetComponent<Text>().color = colorJump;
                }
            }
        }
        else if (fadeKeysIn) {
            if (color.a < 1) {
                color.a += 0.01f;
                colorMove.a += 0.01f;
                if (scene.name == "Level1") {
                    colorJump.a += 0.01f;
                }

                GetComponent<SpriteRenderer>().color = color;
                move.GetComponent<Text>().color = colorMove;
                if (scene.name == "Level1") {
                    jump.GetComponent<Text>().color = colorJump;
                }
            }
        }
    }

    public void FadeKeysIn() {
        fadeKeysIn = true;
        Invoke("FadeKeysOut", 4f);
    }
    public void FadeKeysOut() {
        fadeKeysOut = true;
    }
}
