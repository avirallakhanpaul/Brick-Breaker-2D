using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public int score;
    public int lives;
    public Text scoreText;
    public Text livesText;
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
        setLives();
    }

    public void updateScore(int change) {
        score += change;
        setScore();
    }
}
