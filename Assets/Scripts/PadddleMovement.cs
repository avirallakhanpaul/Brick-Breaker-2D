using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadddleMovement : MonoBehaviour {
    public float horizontalSpeed = 5.0f;
    public float leftScreenEdge = -15.05f;
    public float rightScreenEdge = -11.4f;
    public GameManager gameManager;
    void Start() {

    }
    void Update() {

        if(gameManager.isGameOver) {
            return;
        }

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