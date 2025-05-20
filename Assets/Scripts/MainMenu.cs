using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Load the next scene (assumes build index order)
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Load the menu scene (assuming it's at build index 0, or you can use scene name)
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0); // Or use: SceneManager.LoadScene("MainMenu")
    }

    // Optional: Exit game
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
