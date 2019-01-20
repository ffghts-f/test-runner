using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void HandleStartClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void RestartGame()
    {
		SceneManager.LoadScene("SampleScene");
	}
}