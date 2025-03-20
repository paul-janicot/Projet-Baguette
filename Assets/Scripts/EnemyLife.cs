using UnityEngine;

// Joa

public class EnemyLife : MonoBehaviour
{
    private Rigidbody _rb;

    [SerializeField] private float impactFrameTime;

    [SerializeField] private EnemyData enemyData;

    [SerializeField] private GameObject hitVFX;

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
                    // Drop item
                }

                Destroy(gameObject);
            }

            _rb.AddForce(other.transform.forward * attackData.enemyKnockback, ForceMode.Impulse); //KnockBack

            //ImpactFrameManager.instance.PlayImpactFrame(impactFrameTime, 0.1f);
        }
    }
}
