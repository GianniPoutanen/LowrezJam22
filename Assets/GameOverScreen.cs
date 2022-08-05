using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;

    public void SetGameOver()
    {
        gameOverScreen.SetActive(true); //needs to be activated by all sheep killed
    }

    public void retry ()
    {
        SceneManager.LoadScene(1);
    }

    public void quitgame ()
    {
        Application.Quit();
    }
}
