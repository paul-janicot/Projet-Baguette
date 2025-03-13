using UnityEngine;

public class ImpactFrameManager : MonoBehaviour
{
    public static ImpactFrameManager instance;

    private float impactFrameTimer;

    private void Awake()
    {
        instance = this;
    }

    public void PlayImpactFrame(float time, float timeChange)
    {

    }
}
