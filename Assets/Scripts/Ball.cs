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
    public Transform LifePowerUpPrefab;
    public Transform DeathPowerUpPrefab;
    public Transform SplitPowerUpPrefab;
    public GameManager gameManager;

    void Start() {

        BallRigidBody = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        gameManager.gameOverCanvas.SetActive(false);
        gameManager.levelClearCanvas.SetActive(false);

        isPlaying = false;

        if(BallRigidBody.name.Contains("Clone")) {
            startGame();
        }
    }

    void Update() {

        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.ClampMagnitude(this.gameObject.GetComponent<Rigidbody2D>().velocity, 8);

        if(gameManager.isGameOver) {

            BallRigidBody.gameObject.SetActive(false);
            return;
        }

        if(!isPlaying) {

            if(gameManager.ballClones == 0 && this.gameObject.name == "Ball") {

                this.gameObject.SetActive(true);
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
    }

    void OnTriggerEnter2D(Collider2D obj) {

        if(obj.CompareTag("Bottom Edge")) {

            isPlaying = false;
            gameManager.updateLives(-1);
            
            if(gameManager.lives <= 0) {
                this.gameObject.SetActive(false);
            }

            if(this.gameObject.name == "Ball Clone(Clone)") {

                gameManager.ballClones--;
                Destroy(this.gameObject);
            }
        }
    }

    void resetBallPosition() {

        BallRigidBody.velocity = Vector2.zero;
        BallRigidBody.gameObject.transform.position = new Vector2((BallPosition.transform.position.x), BallPosition.transform.position.y);
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
                    
                    Transform newExplosion = Instantiate(brickScript.brickExplosionPrefab.transform, obj.transform.position, obj.transform.rotation);

                    gameManager.noOfBricks = gameManager.noOfBricks - 1;

                    gameManager.updateScore(brickScript.points);

                    Destroy(obj.gameObject);
                    Destroy(newExplosion.gameObject, 2.5f);

                    if (Mathf.Floor(Random.Range(0.0f, 12.0f)) == Mathf.Floor(Random.Range(0.0f, 12.0f))) {

                        Instantiate(LifePowerUpPrefab, obj.transform.position, obj.transform.rotation);
                    } else if (Mathf.Floor(Random.Range(0.0f, 8.0f)) == Mathf.Floor(Random.Range(0.0f, 8.0f))) {

                        Instantiate(DeathPowerUpPrefab, obj.transform.position, obj.transform.rotation);
                    } else if (Mathf.Floor(Random.Range(0.0f, 10.0f)) == Mathf.Floor(Random.Range(0.0f, 10.0f))) {

                        Instantiate(SplitPowerUpPrefab, obj.transform.position, obj.transform.rotation);
                    }
                }
            }
        }
    }
}