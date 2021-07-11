using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;

    private static bool lvlOneIsActivated = false;
    private static bool lvlOneJade = false;

    public void OnTriggerEnter2D(Collider2D collision) {
        Scene scene = SceneManager.GetActiveScene();
        if (!lvlOneIsActivated) {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            lvlOneIsActivated = true;
        }
        else if (!lvlOneJade && gameObject.name == "Jade") {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            lvlOneJade = true;
        }
        else if (scene.name != "Level1") {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }
    public static bool GetJadeLvlOne() {
        return lvlOneJade;
    }
}
