using System.Collections;
using UnityEngine;

public class SceneLoader : MonoBehaviour {

    public Animator fadeWhite;

    private static Animator fW;
    private static bool whiteFade = false;

    void Start() {
        fW = fadeWhite;
    }

    void Update() {
        fadeWhite.SetBool("WhiteFade", whiteFade);
    }
    public static void DoWhiteFade() {
        fW.SetTrigger("Start");
        whiteFade = true;
    }
    public void ResetWhiteFade() {
        whiteFade = false;
    }
    public void ResetScene() {
        GameManager.ResetLevel();
    }
}
