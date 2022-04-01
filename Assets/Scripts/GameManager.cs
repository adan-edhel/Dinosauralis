using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (FindObjectsOfType<GameManager>().Length > 1)
        {
            Destroy(gameObject);
        }
    }

    public void TitleScreen()
    {
        SceneManager.LoadScene(0);
    }
}
