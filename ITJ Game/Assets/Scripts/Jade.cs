using UnityEngine;

public class Jade : MonoBehaviour {

    public GameObject player;
    public Collider2D jadeCollider;

    public void OnTriggerEnter2D(Collider2D collision) {
        jadeCollider.enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
