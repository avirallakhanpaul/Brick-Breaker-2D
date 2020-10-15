using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayAgain : MonoBehaviour
{
    public void loadLevel() {
        SceneManager.LoadScene("Level01");
    }
}
