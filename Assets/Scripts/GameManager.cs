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
    private int levelNumber;
    public bool forMobile;
    public bool isGameOver;
    void Start() {

        Scene currScene = SceneManager.GetActiveScene();
        
        if (currScene.buildIndex == 0)
        {
            lives = 2;
        }
        else if (currScene.buildIndex > 0)
        {
            lives = 3;
        }
        
        setScore();
        setLives();

        noOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        
        levelNumber = 1;
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
        SceneManager.LoadScene("Level0" + levelNumber);
    }

    public void nextLevel() {

        levelNumber++;
        SceneManager.LoadScene("Level0" + levelNumber);
    }

    public void quitGame() {
        Application.Quit();
    }
}
