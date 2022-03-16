using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int Score;
    private float Timer;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void TitleScreen()
    {
        SceneManager.LoadScene(0);
    }
    public void ShowSettings()
    {
        // Show Settings
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
