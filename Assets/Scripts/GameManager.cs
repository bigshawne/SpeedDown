using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Use UnityEngine.UI to control the time counter
using UnityEngine.UI;
// Use UnityEngine.SceneManagement to control the end scene
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    // Get the text gameobject
    public Text timeScore;
    // Start is called before the first frame update

    public GameObject gameOverUI;
    private void Awake() 
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }    
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        // Use "00" to only show the two-digit integer part.
        // Use the timeSinceLevelLoad method to reset the time when the game is restarted.
        timeScore.text = Time.timeSinceLevelLoad.ToString("00");
    }

    public void RestartGame()
    {
        // Reload the game scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public static void GameOver(bool dead)
    {
        if (dead)
        {
            instance.gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
