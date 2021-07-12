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

    public void QuitGame() {
        Application.Quit();
    }
}
