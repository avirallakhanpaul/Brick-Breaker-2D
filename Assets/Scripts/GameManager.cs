using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public int score;
    public int lives;
    public Text scoreText;
    public Text livesText;
    public Text gameOverScore;
    public GameObject gameOverCanvas;
    public bool isGameOver;
    void Start() {
        setScore();
        setLives();
    }

    void Update() {
        
    }

    void setScore() {
        scoreText.text = "Score: " + score;
    }

    void setLives() {
        livesText.text = "Lives: " + lives;
    }

    public void updateLives(int change) {

        lives += change;

        if(lives <= 0) {
            lives = 0;
            gameOver();
        }
        setLives();
    }

    public void updateScore(int change) {

        score += change;
        setScore();
    }

    void gameOver() {

        isGameOver = true;
        gameOverCanvas.SetActive(true);
        Instantiate(gameOverCanvas);
        gameOverScore.text = "Score: " + score;
    }

    public void loadLevel() {
        SceneManager.LoadScene("Level01");
    }
}
