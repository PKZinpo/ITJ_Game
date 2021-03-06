using UnityEngine;

public class TitleScreen : MonoBehaviour {

    public void StartGame() {
        DialogueTrigger.lvlOneIsActivated = false;
        DialogueTrigger.lvlOneJade = false;
        DialogueTrigger.lvlTwoIsActivated = false;
        DialogueTrigger.lvlThreeIsActivated = false;
        DialogueTrigger.final = false;
        SceneLoader.LoadLevel("Level1");
    }

    void Update() {
        if (GameObject.FindGameObjectsWithTag("Audio").Length != 0) {
            foreach (var item in GameObject.FindGameObjectsWithTag("Audio")) {
                Destroy(item);
            }
        }
    }

    public void QuitGame() {
        Application.Quit();
    }
}
