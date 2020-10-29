using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Instructions : MonoBehaviour {

    private int counter = 3;
    private float time = 0f;
    public Text counterText; 
    void Start() {

        counterText.text = counter.ToString();
        
        Invoke("loadFirstLevel", time);
        // InvokeRepeating("updateCounterText", 0f, 1f);

        // if(counter > 0) {
        //     updateCounterText();
        // } else {
        //     return;
        // }
    }

    void loadFirstLevel() {
        SceneManager.LoadScene(1);
    }

    void updateCounterText() {

        // counterText.text = time.ToString();
        // time--;

        if(counter > 0) {

            Debug.Log("inside if");
            // time += 1f;
            counterText.text = counter.ToString();
            counter--;
        } else {
            return;
        }
        
    }
    // void Update() {

    //     if(counter <= 0) {
    //         return;
    //     } else {

    //         if(Time.time >= time) {

    //             Debug.Log("inside if");
    //             time += 1f;
    //             counterText.text = counter.ToString();
    //             counter--;
    //         }
    //     }
    // }
}
