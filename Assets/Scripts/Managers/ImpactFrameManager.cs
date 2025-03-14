using UnityEngine;

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

    public void PlayImpactFrame(float time, float timeChange)
    {
        Debug.Log("tha warudo");
        if (impactFrameTimer > 0)
        {
            if (impactFrameTimer * Time.timeScale < time)
            {
                impactFrameTimer = time * timeChange;
                Time.timeScale = timeChange;
            }
        }
    }
}
