using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watcher : MonoBehaviour {

    public Transform leftWaypoint;
    public Transform rightWaypoint;
    public float watcherSpeed;
    public float waitTime;
    public bool toRight = false;
    public static bool allowMoving = true;

    private bool isMoving = false;
    
    void Update() {
        if (allowMoving) {
            if (!isMoving) {
                StartCoroutine(WatcherMove());
                isMoving = true;
            }
        }
        else {
            StopAllCoroutines();
        }
    }

    IEnumerator WatcherMove() {
        if (toRight) {
            Vector3 right = new Vector3(rightWaypoint.transform.position.x, transform.position.y, transform.position.z);
            while (transform.position != right) {
                transform.position = Vector3.MoveTowards(transform.position, right, watcherSpeed * Time.deltaTime);
                yield return null;
            }
        }
        else {
            Vector3 left = new Vector3(leftWaypoint.transform.position.x, transform.position.y, transform.position.z);
            while (transform.position != left) {
                transform.position = Vector3.MoveTowards(transform.position, left, watcherSpeed * Time.deltaTime);
                yield return null;
            }
        }
        yield return new WaitForSeconds(waitTime);
        isMoving = false;
        toRight = !toRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
