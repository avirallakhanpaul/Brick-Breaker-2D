using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Rigidbody2D BallRigidBody;
    public GameObject BallPosition;
    public float ballOffsetY = 0.25f;
    private bool isPlaying;
    public float force = 300f;
    void Start() {

        isPlaying = false;

        BallRigidBody = GetComponent<Rigidbody2D>();
    }
    void Update() {

        if(!isPlaying) {
            resetBallPosition();

            if(Input.GetKey(KeyCode.Space)) {
                startGame();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D obj) {

        if(obj.CompareTag("Bottom Edge")) {
            Debug.Log("Ball hit the bottom of the screen");
            isPlaying = false;
        }
    }

    void resetBallPosition() {

        BallRigidBody.velocity = Vector2.zero;
        transform.position = new Vector2((BallPosition.transform.position.x), BallPosition.transform.position.y);
    }

    void startGame() {

        isPlaying = true;
        BallRigidBody.AddForce(Vector2.up * force);
    }
}
