using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public int score;
    public int lives;
    public int noOfBricks;
    public int ballClones = 0;
    public Text scoreText;
    public Text scoreTextGreen;
    public Text livesText;
    public Text livesTextGreen;
    public Text livesTextRed;
    public Text levelText;
    public Text gameOverScore;
    public Text levelClearScore;
    public GameObject gameOverCanvas;
    public GameObject levelClearCanvas;
    public bool forMobile;
    public bool isGameOver;
    void Start() {

        Scene currScene = SceneManager.GetActiveScene();
        
        if(currScene.buildIndex == 0) {
            lives = 2;
        }
        else if(currScene.buildIndex > 0) {
            lives = 3;
        }
        
        setScore();
        setLives();
        setLevel();

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

    void setLevel() {
        levelText.text = "Level " + SceneManager.GetActiveScene().buildIndex;
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

        if(lives <= 0 ) {  // || (ballClones == 0 && !GameObject.FindGameObjectWithTag("Ball").activeInHierarchy)
            
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

    public void gameOver() {

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

    public void restartGame() {
        SceneManager.LoadScene(0);
    }
}
