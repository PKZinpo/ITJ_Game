using UnityEngine;

public class LevelTwoInitial : MonoBehaviour {

    public Collider2D colliderInitial;
    public GameObject player;

    void Start() {
        if (SceneLoader.resetVal == 0) {
            Invoke("StartDialogue", 1f);
        }
    }
    public void StartDialogue() {
        colliderInitial.enabled = true;
    }
    public void OnTriggerEnter2D(Collider2D collision) {
        colliderInitial.enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
