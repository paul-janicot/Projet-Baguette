using UnityEngine;
using UnityEngine.SceneManagement;

// Joa

public class MainMenuScript : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }
    public void Play()
    {
        SceneManager.LoadScene("Night");
    }
}
