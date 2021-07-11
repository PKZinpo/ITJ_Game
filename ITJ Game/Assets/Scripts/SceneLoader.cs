using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public Animator fadeWhite;
    public Animator fadeBlack;
    public string nextLevel;

    private static Animator fW;
    private static Animator fB;
    private static bool whiteFade = false;

    void Start() {
        fW = fadeWhite;
        fB = fadeBlack;
        if (!whiteFade) {
            fadeBlack.SetBool("FadeWhite", false);
        }
    }

    void Update() {
        fadeWhite.SetBool("WhiteFade", whiteFade);
    }
    public static void DoWhiteFade() {
        fW.SetTrigger("Start");
        whiteFade = true;
    }
    public static void DoWhiteFadeLevelOne() {
        fW.SetTrigger("StartOne");
        whiteFade = true;
    }
    public static void LoadLevel(string levelName) {
        fB.SetTrigger("Start");
        SceneManager.LoadScene(levelName);
        DialogueManager.isOpen = false;
    }
    public void ResetWhiteFade() {
        whiteFade = false;
    }
    public void ResetScene() {
        GameManager.ResetLevel();
    }
    public void ToNextLevel() {
        SceneManager.LoadScene(nextLevel);
        DialogueManager.isOpen = false;
    }
}
