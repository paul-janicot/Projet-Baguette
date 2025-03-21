using GLTFast.Schema;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Script : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = InventoryManager.score;
        scoreText.text = "Score :" + "\n"+ score;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("DayMenu_Baptiste");
    }
    public void Replay()
    {
       SceneManager.LoadScene("Night");
    }
}
