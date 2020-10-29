using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public GameObject powerupPrefab;
    public int LifePowerUp = 1;
    public int DeathPowerUp = -1;
    
    void OnTriggerEnter2D(Collider2D obj) {

        if(obj.CompareTag("Paddle") || obj.CompareTag("Bottom Edge")) {
            this.gameObject.SetActive(false);
        }
    }
}
