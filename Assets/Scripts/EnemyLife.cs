using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    private Rigidbody _rb;

    [SerializeField] private float impactFrameTime;

    [SerializeField] private EnemyData enemyData;

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

            _rb.AddForce(other.transform.forward * attackData.enemyKnockback, ForceMode.Impulse);
            ImpactFrameManager.instance.PlayImpactFrame(impactFrameTime, 0.1f);
        }
    }
}
