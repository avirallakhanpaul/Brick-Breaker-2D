using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Padddle : MonoBehaviour {
    
    public float horizontalSpeed = 5.0f;
    public float leftScreenEdge = -18.0f;
    public float rightScreenEdge = -11.25f;
    public GameObject BallClonePrefab;
    public GameManager gameManager;
    
    void Update() {

        if(gameManager.isGameOver) {
            return;
        }

        if(gameManager.forMobile) {

            horizontalSpeed = 15.0f;
            float horizontalAxisSpeed = Input.acceleration.x * horizontalSpeed;
            transform.Translate(Vector2.right * horizontalAxisSpeed * Time.deltaTime);
        } else {

            float horizontalAxisSpeed = Input.GetAxis("Horizontal") * horizontalSpeed;
            transform.Translate(Vector2.right * horizontalAxisSpeed * Time.deltaTime);
        }

        if(transform.position.x > rightScreenEdge) {
            transform.position = new Vector2(rightScreenEdge, transform.position.y);
        }

        if(transform.position.x < leftScreenEdge) {
            transform.position = new Vector2(leftScreenEdge, transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D obj) {

        if(gameManager.isGameOver) {
            return;
        }

        if(obj.gameObject.CompareTag("Life Powerup")) {

            gameManager.updateLives(obj.gameObject.GetComponent<PowerUp>().LifePowerUp);
            Destroy(obj.gameObject);
        } else if(obj.gameObject.CompareTag("Death Powerup")) {

            gameManager.updateLives(obj.gameObject.GetComponent<PowerUp>().DeathPowerUp);
            Destroy(obj.gameObject);
        } else if(obj.gameObject.CompareTag("Split Powerup")) {
            
            GameObject newBall = Instantiate(BallClonePrefab);
            Debug.Log(GameObject.FindGameObjectWithTag("Ball"));

            if(GameObject.FindGameObjectWithTag("Ball") != null) {

                newBall.transform.position = GameObject.FindGameObjectWithTag("Ball").transform.position;
            } else {
                newBall.transform.position = GameObject.FindGameObjectWithTag("Ball Clone").transform.position;
            }

            gameManager.ballClones++;
        }
    }

    void OnCollisionEnter2D(Collision2D obj) {

        if(obj.gameObject.name == "Ball" || obj.gameObject.name == "Ball Clone") {

            obj.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 50f);
            Debug.Log("Force Added");
        }
    }
}