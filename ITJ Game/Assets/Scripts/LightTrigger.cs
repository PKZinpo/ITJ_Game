using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightTrigger : MonoBehaviour {

    public GameObject player;

    private Collider2D playerCollider;

    void Start() {
        playerCollider = player.GetComponent<BoxCollider2D>();
    }

    void Update() {

    }

    void OnTriggerStay2D(Collider2D collision) {
        if (!PlayerMovement.isHiding) {
            var height = player.GetComponent<BoxCollider2D>().bounds.size.y;
            RaycastHit2D topHit = Physics2D.Raycast(transform.position, player.transform.position - transform.position + new Vector3(0.0f, height, 0.0f));
            RaycastHit2D middleHit = Physics2D.Raycast(transform.position, player.transform.position - transform.position + new Vector3(0.0f, height / 2, 0.0f));
            RaycastHit2D bottomHit = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
            if (topHit.collider || middleHit.collider || bottomHit.collider != null) {
                if (topHit.collider || middleHit.collider || bottomHit.collider == playerCollider) {
                    Color color = GetComponent<Light2D>().color;
                    color.g = 0f;
                    color.b = 0f;
                    color.r = 150f;
                    GetComponent<Light2D>().color = color;
                    Watcher.allowMoving = false;
                    player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    Invoke("RestartLevel", 2f);
                }
            }
        }        
    }

    public void RestartLevel() {
        GameManager.ResetLevel();
    }
}
