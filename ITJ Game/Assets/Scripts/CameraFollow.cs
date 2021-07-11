using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour {

    public Transform levelOne;
    public Transform player;
    public Transform bigSamurai;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Vector3 levelOneOffset;

    private Scene currentScene;
    private Transform target;

    void Start() {
        currentScene = SceneManager.GetActiveScene();
    }

    void Update() {
        if (currentScene.name != "Level1") {
            if (target == bigSamurai) {
                Vector3 desiredPos = target.position + offset;
                Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
                transform.position = smoothedPos;
            }
        }
    }

    void FixedUpdate() {
        if (currentScene.name == "Level1") {
            Vector3 targetPos = levelOne.transform.position + levelOneOffset;
            if (transform.position != targetPos) {
                transform.position = targetPos;
            }
        }
        else {
            if (BigSamurai.isTouching) {
                target = bigSamurai;
                smoothSpeed = 0.01f;
            }
            else {
                target = player;
                smoothSpeed = 0.125f;
            }
            if (target == player) {
                Vector3 desiredPos = target.position + offset;
                Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
                transform.position = smoothedPos;
            }
        }
    }
}
