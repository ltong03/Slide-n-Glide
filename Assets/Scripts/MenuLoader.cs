using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoader : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
