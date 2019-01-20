using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public List<GameObject> Obstacles = new List<GameObject>();
    
    private void Start()
    {
        // Beim Beginn des Spiels, starte die Courotine.
        StartCoroutine(SpawnObstacles());
    }

    /// <summary>
    /// Spawne alle 3 Sekunden ein Hinderniss, welches in der Obstacles Liste ist.
    /// </summary>
    /// <returns>Das ist nicht wirklich wichtig.</returns>
    private IEnumerator SpawnObstacles()
    {
        while (!GameManager.GameOver) // Stops spawning obstacles when Player is dead
        {
                int spawnElement = Random.Range(0, Obstacles.Count);
                Instantiate(Obstacles[spawnElement]);
                yield return new WaitForSeconds(3);
        }
    }
}