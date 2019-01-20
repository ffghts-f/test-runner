using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool GameOver;

    public Button RestartButton;

    private void Awake()
    {
        RestartButton.gameObject.SetActive(false);
        GameOver = false;
    }

    private void Update()
    {
        if (GameOver)
        {
            RestartButton.gameObject.SetActive(true);
        }
    }
}
