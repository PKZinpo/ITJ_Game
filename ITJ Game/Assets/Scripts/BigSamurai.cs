using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSamurai : MonoBehaviour {

    public Transform bottomLeft;
    public Transform topRight;
    public LayerMask whatIsPlayer;

    private bool isTouching = false;

    void Update() {

        isTouching = Physics2D.OverlapArea(bottomLeft.transform.position, topRight.transform.position, whatIsPlayer);
        
        if (isTouching) {
            GameManager.ResetLevel();
        }

    }

    


}
