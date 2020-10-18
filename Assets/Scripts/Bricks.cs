using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour {

    public int points;
    public int hits;
    public Material brickHit1Material;

    public void breakBrick() {
        
        hits--;
        GetComponent<SpriteRenderer>().material = brickHit1Material;
    }
}
