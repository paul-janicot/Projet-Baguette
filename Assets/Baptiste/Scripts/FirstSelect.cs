using UnityEngine;
using UnityEngine.UI;

// Joa

public class FirstSelect : MonoBehaviour
{
    [SerializeField] private GameObject startButton;

    private void Start()
    {
        startButton.GetComponent<Button>().Select();
    }
}
