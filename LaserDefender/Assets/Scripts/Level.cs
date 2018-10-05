using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private float delayInSeconds = 2f;
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        if (GameSession.Instance != null)
        {
            GameSession.Instance.ResetGame();
        }

        SceneManager.LoadScene("InGame");
    }

    public void LoadGameOver()
    {
        StartCoroutine(DelayLoadGameOver());        
    }

    private IEnumerator DelayLoadGameOver()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game Over");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
