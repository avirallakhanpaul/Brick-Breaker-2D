using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public int score;
    public int lives;
    public int noOfBricks;
    public Text scoreText;
    public Text livesText;
    public Text gameOverScore;
    public Text levelClearScore;
    public GameObject gameOverCanvas;
    public GameObject levelClearCanvas;
    public bool forMobile;
    public bool isGameOver;
    void Start() {

        setScore();
        setLives();
        noOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
    }

    void setScore() {
        scoreText.text = "Score: " + score;
        if(score == 10) {
            Debug.Log("Score = 10");
        }
    }

    void setLives() {
        livesText.text = "Lives: " + lives;
    }

    public void updateLives(int change) {

        Debug.Log("Updated Life");

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
        
        if(noOfBricks == 0) {
            levelClear();
        }
    }

    void gameOver() {

        isGameOver = true;
        gameOverCanvas.SetActive(true);
        gameOverScore.text = "Score: " + score;
    }

    void levelClear() {
        isGameOver = true;
        levelClearCanvas.SetActive(true);
        levelClearScore.text = "Score: " + score;
    }

    public void loadLevel() {
        SceneManager.LoadScene("Level01");
    }

    public void quitGame() {
        Application.Quit();
        Debug.Log("Game has been closed");
    }
}
