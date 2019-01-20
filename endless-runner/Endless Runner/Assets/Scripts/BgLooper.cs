using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public float Speed = 0.1f;

    public bool PlayerDead = false;

    // Update is called once per frame
    void Update ()
	{
        //Only moves if the player is not dead
        if (!GameManager.GameOver)
        {
            // Fahre den Boden für jeden Frame weiter nach links.
            transform.position += Vector3.left * Speed * Time.deltaTime;

            // Wenn der Boden bei einer x Position von -10 ist, setze ihn wieder auf 0.
            // So entsteht eine endlose Schleife.
            if (transform.position.x <= -10)
            {
                transform.position = Vector3.zero;
            }
        }
	}
}
