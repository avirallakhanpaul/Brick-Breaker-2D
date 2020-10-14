using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadddleMovement : MonoBehaviour {
    public float horizontalSpeed = 5.0f;
    private float leftScreenEdge = -15.0f;
    private float rightScreenEdge = -11.4f;
    void Start() {

    }
    void Update() {

        float horizontalAxis = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontalAxis * horizontalSpeed * Time.deltaTime);

        if(transform.position.x > rightScreenEdge) {
            transform.position = new Vector2(rightScreenEdge, transform.position.y);
        }

        if(transform.position.x < leftScreenEdge) {
            transform.position = new Vector2(leftScreenEdge, transform.position.y);
        }
    }
}