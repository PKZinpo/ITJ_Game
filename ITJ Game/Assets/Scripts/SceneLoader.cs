using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public Animator fadeWhite;
    public Animator fadeBlack;

    private static Animator fW;
    private static bool whiteFade = false;

    void Start() {
        fW = fadeWhite;
    }

    void Update() {
        fadeWhite.SetBool("WhiteFade", whiteFade);
        fadeBlack.SetBool("FadeWhite", whiteFade);
    }
    public static void DoWhiteFade() {
        fW.SetTrigger("Start");
        whiteFade = true;
    }
    public void LoadLevel(string levelName) {
        fadeBlack.SetTrigger("Start");
        SceneManager.LoadScene(levelName);
    }
    public void ResetWhiteFade() {
        whiteFade = false;
    }
    public void ResetScene() {
        GameManager.ResetLevel();
    }
}
