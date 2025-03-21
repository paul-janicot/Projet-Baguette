using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// Joa

public class Timer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField] private GameObject end;
    [SerializeField] private GameObject other;

    private float timer;

    private void Awake()
    {
        timer = time;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        timerText.text = Mathf.Round(timer).ToString();

        if (timer <= 0)
        {
            other.SetActive(false);
            end.SetActive(true);

            Time.timeScale = 0.1f;

            if (timer <= -0.2f)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("DayMenu_Baptiste");
            }
        }

    }
}
