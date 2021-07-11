using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;
    public Text continueText;
    public Animator boxAnim;
    public Animator slash;
    public GameObject player;
    public static bool isOpen = false;

    private Queue<string> names;
    private Queue<string> sentences;

    void Start() {
        names = new Queue<string>();
        sentences = new Queue<string>();
    }

    void Update() {
        if (continueText.enabled) {
            if (Input.GetKeyDown(KeyCode.F)) {
                NextSentence();
            }
        }
    }
    public void StartDialogue(Dialogue dialogue) {
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        isOpen = true;
        names.Clear();
        sentences.Clear();
        boxAnim.SetBool("IsOpen", isOpen);
        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }
        foreach (string dialogueName in dialogue.name) {
            names.Enqueue(dialogueName);
        }
        NextSentence();
    }
    public void NextSentence() {
        continueText.enabled = false;
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        string name = names.Dequeue();
        nameText.text = name;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence (string sentence) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
        continueText.enabled = true;
    }
    public void EndDialogue() {
        isOpen = false;
        boxAnim.SetBool("IsOpen", isOpen);
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Level1") {
            if (!FindObjectOfType<Jade>().GetComponent<CircleCollider2D>().enabled) {
                isOpen = true;
                Invoke("WhiteSlash", 2f);
            }
        }
    }

    public void WhiteSlash() {
        slash.SetTrigger("Slash");
    }
}
