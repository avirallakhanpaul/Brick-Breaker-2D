using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Instructions : MonoBehaviour {

    public int counter = 3;
    private float time = 3f;
    public Text counterText; 
    void Start() {
        
        Invoke("loadFirstLevel", time);
        InvokeRepeating("updateCounterText", 1f, 1f);

        if(counter > 0) {
            updateCounterText();
        } else {
            return;
        }
    }

    void loadFirstLevel() {
        SceneManager.LoadScene(1);
    }

    void updateCounterText() {

        if(counter > 0) {

            counterText.text = counter.ToString();
            counter--;
        } else {
            return;
        }
        
    }
}
