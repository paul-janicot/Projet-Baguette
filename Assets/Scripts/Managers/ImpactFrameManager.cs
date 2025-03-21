using UnityEngine;

// Joa

public class ImpactFrameManager : MonoBehaviour
{
    public static ImpactFrameManager instance;

    private float impactFrameTimer;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        impactFrameTimer -= Time.deltaTime;

        if (impactFrameTimer <= 0)
        {
            Time.timeScale = 1;
        }
    }

    public void PlayImpactFrame(float time, float timeChange) // If there is another impact frame timer and it is bigger than the current one, don't change it
    {
        if (impactFrameTimer > 0)   
        {
            if (impactFrameTimer * Time.timeScale < time)
            {
                impactFrameTimer = time * timeChange;
                Time.timeScale = timeChange;
            }
        }
        else
        {
            impactFrameTimer = time * timeChange;
            Time.timeScale = timeChange;
        }
    }
}
