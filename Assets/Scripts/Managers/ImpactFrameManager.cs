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

        Debug.Log(Time.timeScale);
    }

    public void PlayImpactFrame(float time, float timeChange)
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
