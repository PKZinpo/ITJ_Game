using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;

    private static bool lvlOneIsActivated = true;
    private static bool lvlOneJade = true;
    private static bool lvlTwoIsActivated = false;
    private static bool lvlThreeIsActivated = false;

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
        else if (scene.name == "Level3" && !lvlThreeIsActivated) {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            lvlThreeIsActivated = true;
        }
        else if (scene.name == "Level2" && !lvlTwoIsActivated) {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            lvlTwoIsActivated = true;
        }
    }
}
