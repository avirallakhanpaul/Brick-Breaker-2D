using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadddleMovement : MonoBehaviour {
    public float horizontalSpeed = 5.0f;
    private float leftScreenEdge = -1.71f;
    private float rightScreenEdge = 1.71f;
    void Start() {

    }
    void Update() {

        float horizontalAxis = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontalAxis * horizontalSpeed * Time.deltaTime);

        if(transform.position.x > 1.71) {
            transform.position = new Vector2(rightScreenEdge, transform.position.y);
        }

        if(transform.position.x < -1.71) {
            transform.position = new Vector2(leftScreenEdge, transform.position.y);
        }
    }
}