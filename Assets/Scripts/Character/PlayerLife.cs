using UnityEngine;
using UnityEngine.SceneManagement;

// Joa

public class PlayerLife : MonoBehaviour
{
    public static PlayerLife instance;

    [SerializeField] private float maxHP;
    [SerializeField] private GameObject damageVFX;
    [SerializeField] private float invinciblityTime;

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

    private void FixedUpdate()
    {
        invincibilityTimer -= Time.deltaTime;
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
