using UnityEngine;

public class SineMovement : MonoBehaviour {

    [SerializeField] private float frequency;
    [SerializeField] private float magnitude;
    [SerializeField] private float offset;
    private Vector3 startPosition;

    void Start() {
        startPosition = transform.position;
    }

    void Update() {
        transform.position = startPosition + transform.up * Mathf.Sin(Time.time * frequency + offset) * magnitude;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
    }
}
