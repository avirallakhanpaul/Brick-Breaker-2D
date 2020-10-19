using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public GameObject powerupPrefab;
    public int LifePowerUp = 1;
    public int DeathPowerUp = -1;
    
    void OnTriggerEnter2D(Collider2D obj) {

        if(obj.CompareTag("Paddle")) {
            Destroy(GetComponent<GameObject>());
        } else if(obj.CompareTag("Bottom Edge")) {
            Destroy(powerupPrefab.gameObject);
        }
    }
}
