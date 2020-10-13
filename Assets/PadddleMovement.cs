using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadddleMovement : MonoBehaviour
{

    public horizontalSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        public horizontalAxis = Input.GetAxis("Horizontal");

        transform.Translate.right = horizontalAxis * horizontalSpeed * Time.deltaTime;
    }
}
