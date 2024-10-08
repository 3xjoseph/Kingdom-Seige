using UnityEngine;
using UnityEngine.SceneManagement;

public class Paused : MonoBehaviour
{
    int currentSceneIndex;
    public void RestartGame()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;   
        SceneManager.LoadScene(currentSceneIndex);

        FindObjectOfType<AudioListener>().enabled = true;
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exited the Game");
    } 
}
