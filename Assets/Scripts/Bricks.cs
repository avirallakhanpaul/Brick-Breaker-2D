using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour {

    public int points;
    public int hits;
    public GameObject brickExplosionPrefab;
    public Sprite brickSprite;

    public void breakBrick() {
        
        hits--;
        GetComponent<SpriteRenderer>().sprite = brickSprite;

        Vector2 scale = new Vector2(0.671f, 0.810f);
        GetComponent<Transform>().localScale = scale;
    }
}
