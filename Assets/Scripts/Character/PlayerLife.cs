using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Joa

public class PlayerLife : MonoBehaviour
{
    public static PlayerLife instance;

    [SerializeField] private float maxHP;
    [SerializeField] private GameObject damageVFX;
    [SerializeField] private float invinciblityTime;

    [SerializeField] private Image lifeBar;
    [SerializeField] private Image invincibilityFeedback;

    public float hp;

    private float invincibilityTimer;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        hp = maxHP;
    }

    private void Update()
    {
        invincibilityTimer -= Time.deltaTime;

        if (invincibilityTimer > 0)
        {
            invincibilityFeedback.color = new Color(invincibilityFeedback.color.r, invincibilityFeedback.color.g, invincibilityFeedback.color.b, invincibilityTimer / invinciblityTime);
        }
        else
        {
            invincibilityFeedback.color = new Color(invincibilityFeedback.color.r, invincibilityFeedback.color.g, invincibilityFeedback.color.b, 0);
        }

        lifeBar.fillAmount = hp/maxHP;
    }

    public void TakeDamage(float damage)
    {
        if (invincibilityTimer <= 0)
        {
            Destroy(Instantiate(damageVFX, transform.position, Quaternion.identity), 1f);

            invincibilityTimer = invinciblityTime;
            hp -= damage;
            if (hp <= 0)
            {
                //SceneManager.LoadScene("")
            }
        }
    }

}
