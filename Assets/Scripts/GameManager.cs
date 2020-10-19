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
    public Text scoreTextGreen;
    public Text livesText;
    public Text livesTextGreen;
    public Text livesTextRed;
    public Text gameOverScore;
    public Text levelClearScore;
    public GameObject gameOverCanvas;
    public GameObject levelClearCanvas;
    private int levelNumber = 1;
    public bool forMobile;
    public bool isGameOver;
    void Start() {

        Scene currScene = SceneManager.GetActiveScene();
        
        if (currScene.buildIndex == 0) {
            lives = 2;
        }
        else if (currScene.buildIndex > 0) {
            lives = 3;
        }
        
        setScore();
        setLives();

        noOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
    }

    void setScore() {
        scoreText.text = "Score: " + score;
        scoreTextGreen.text = "Score: " + score;
    }

    void setLives() {
        livesText.text = "Lives: " + lives;
        livesTextGreen.text = "Lives: " + lives;
        livesTextRed.text = "Lives: " + lives;
    }

    public void updateLives(int change) {

        if(change > 0) {

            livesText.gameObject.SetActive(false);
            livesTextGreen.gameObject.SetActive(true);
            Invoke("animate", 0.5f);
        } else if(change < 0) {

            livesText.gameObject.SetActive(false);
            livesTextRed.gameObject.SetActive(true);
            Invoke("animate", 0.5f);
        }

        lives += change;

        if(lives <= 0) {
            lives = 0;
            gameOver();
        }
        
        setLives();
    }

    void animate() {

        livesTextGreen.gameObject.SetActive(false);
        livesTextRed.gameObject.SetActive(false);
        livesText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        scoreTextGreen.gameObject.SetActive(false);
    }

    public void updateScore(int change) {
        
        if(change > 0) {
            scoreText.gameObject.SetActive(false);
            scoreTextGreen.gameObject.SetActive(true);
            Invoke("animate", 0.5f);
        }
        
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

    public void playAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void nextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitGame() {
        Application.Quit();
    }
}
