using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float Speed = 1f;

    private void Update()
    {
        if (!GameManager.GameOver)
        {
            // Fahre mit der selben Geschwindigkeit wie der Hintergrund nach links.
            transform.position += Vector3.left * Speed * Time.deltaTime;

            // Wenn das Hinderniss zu weit aus der Karte ist, zerstöre es.
            if (transform.position.x <= -18)
            {
                Destroy(gameObject);
            }
         }
    }
}