using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Rigidbody2D BallRigidBody;
    public GameObject BallPosition;
    public float force = 300f;
    public float ballOffsetY = 0.25f;
    private bool isPlaying;
    public Transform BrickExplosionPrefab;
    public GameManager gameManager;
    void Start() {

        BallRigidBody = GetComponent<Rigidbody2D>();
        isPlaying = false;
        gameManager.gameOverCanvas.SetActive(false);
        gameManager.levelClearCanvas.SetActive(false);
    }
    void Update() {

        if(gameManager.isGameOver) {
            return;
        }

        if(!isPlaying) { 
            resetBallPosition();

            if(Input.GetButtonDown("Jump")) {
                startGame();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D obj) {

        if(obj.CompareTag("Bottom Edge")) {
            isPlaying = false;
            gameManager.updateLives(-1);
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

    void OnCollisionEnter2D(Collision2D obj) {

        if(obj.transform.CompareTag("Brick")) {

            Transform newExplosion = Instantiate(BrickExplosionPrefab, obj.transform.position, obj.transform.rotation);

            gameManager.noOfBricks = gameManager.noOfBricks - 1;

            gameManager.updateScore(obj.gameObject.GetComponent<Bricks>().points);

            Destroy(obj.gameObject);
            Destroy(newExplosion.gameObject, 2.5f);
        }
    }
}
