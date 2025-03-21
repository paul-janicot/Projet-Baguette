using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        Destroy(this);
    }
}
