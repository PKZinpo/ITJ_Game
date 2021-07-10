using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    public Transform bigSamurai;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private Transform target;

    void Update() {
        if (target == bigSamurai) {
            Vector3 desiredPos = target.position + offset;
            Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
            transform.position = smoothedPos;
        }
    }

    void FixedUpdate() {
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
