using UnityEngine;

// Joa

public class EnemyLife : MonoBehaviour
{
    private Rigidbody _rb;

    [SerializeField] private float impactFrameTime;

    [SerializeField] private EnemyData enemyData;

    [SerializeField] private GameObject hitVFX;

    [SerializeField] private float knockbackMultiplier;

    [SerializeField] private int numberOfItem;

    private float hp;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        hp = enemyData.hp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttacks"))
        {
            Destroy(Instantiate(hitVFX, transform.position, Quaternion.identity), 1f); // spawn hit vfx and destroy it after 1 second

            AttackData attackData = other.GetComponent<AttackData>();

            hp -= attackData.damage;

            if (hp <= 0)
            {
                if (enemyData.isDropping)
                {
                    for (int i = 0; i < numberOfItem; i++)
                    {
                        GetComponent<LootBag>().InstantiateLoot(transform.position);
                    }
                    
                }

                Destroy(gameObject);
            }

            _rb.AddForce(other.transform.forward * attackData.enemyKnockback, ForceMode.Impulse); //KnockBack
        }
    }
}
