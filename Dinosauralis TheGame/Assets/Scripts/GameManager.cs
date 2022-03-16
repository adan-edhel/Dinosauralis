using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    void Start()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
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
