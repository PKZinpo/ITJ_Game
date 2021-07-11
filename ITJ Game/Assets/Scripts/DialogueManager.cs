using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text dialogueText;
    public Text continueText;
    public Animator boxAnim;
    public Animator slash;
    public GameObject player;
    public static bool isOpen = false;

    private Queue<string> sentences;

    void Start() {
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
        sentences.Clear();
        boxAnim.SetBool("IsOpen", isOpen);
        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
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
        if (!FindObjectOfType<Jade>().GetComponent<CircleCollider2D>().enabled) {
            isOpen = true;
            slash.SetTrigger("Slash");
        }
    }
    public void WhiteFadeLevelOne() {
        SceneLoader.DoWhiteFade();
    }
}
