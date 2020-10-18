using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Rigidbody2D BallRigidBody;
    public GameObject BallPosition;
    public float force = 300f;
    public float ballOffsetY = 0.25f;
    private bool isPlaying;
    private Touch touch;
    public Transform BrickExplosionPrefab;
    public Transform LifePowerUpPrefab;
    public Transform DeathPowerUpPrefab;
    public Transform SplitPowerUpPrefab;
    public GameManager gameManager;
    void Start() {

        BallRigidBody = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        Debug.Log("Start()");
        gameManager.gameOverCanvas.SetActive(false);
        gameManager.levelClearCanvas.SetActive(false);

        if(BallRigidBody.name.Contains("Clone")) {

            isPlaying = false;
            startGame();
        } else {
            isPlaying = false;
        }
    }

    void Update() {

        if(gameManager.isGameOver) {
            BallRigidBody.gameObject.SetActive(false);
            return;
        }

        if(!isPlaying) {
            Debug.Log("resetBallPosition()");
            resetBallPosition();

            if(gameManager.forMobile) {

                if(Input.touchCount >= 0) {
                    touch = Input.GetTouch(0);

                    if(touch.phase == TouchPhase.Began) {
                        startGame();
                    }
                }
            } else if(Input.GetButtonDown("Jump")) {
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

        if(isPlaying) {

            if(obj.transform.CompareTag("Brick")) {

                Bricks brickScript = obj.gameObject.GetComponent<Bricks>();

                if(brickScript.hits > 1) {
                    brickScript.breakBrick();
                } else {

                    Transform newExplosion = Instantiate(BrickExplosionPrefab, obj.transform.position, obj.transform.rotation);

                    gameManager.noOfBricks = gameManager.noOfBricks - 1;

                    gameManager.updateScore(brickScript.points);

                    Destroy(obj.gameObject);
                    Destroy(newExplosion.gameObject, 2.5f);

                    if (Mathf.Floor(Random.Range(0.0f, 12.0f)) == Mathf.Floor(Random.Range(0.0f, 12.0f))) {

                        Instantiate(LifePowerUpPrefab, obj.transform.position, obj.transform.rotation);
                    } else if (Mathf.Floor(Random.Range(0.0f, 10.0f)) == Mathf.Floor(Random.Range(0.0f, 10.0f))) {

                        Instantiate(DeathPowerUpPrefab, obj.transform.position, obj.transform.rotation);
                    } else if (Mathf.Floor(Random.Range(0.0f, 15.0f)) == Mathf.Floor(Random.Range(0.0f, 15.0f))) {

                        Instantiate(SplitPowerUpPrefab, obj.transform.position, obj.transform.rotation);
                    }
                }
            }
        }
    }
}

// Destroy Power-ups when they touch the bottom edge of the screen X
// Create and add other levels (min: 2 levels) 
// Add Texttures to each sprite as well as add background and music to the game