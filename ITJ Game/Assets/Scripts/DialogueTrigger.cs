using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;

    public static bool lvlOneIsActivated = false;
    public static bool lvlOneJade = false;
    public static bool lvlTwoIsActivated = false;
    public static bool lvlThreeIsActivated = false;
    public static bool final = true;

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
        else if (scene.name == "Level3" && gameObject.name == "Jade" && !final) {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            final = true;
        }
        else if (scene.name != "Level1") {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }
}
