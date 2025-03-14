using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttacks"))
        {
            _rb.AddForce(other.transform.forward * other.GetComponent<AttackData>().enemyKnockback, ForceMode.Impulse);
            ImpactFrameManager.instance.PlayImpactFrame(1f, 0.1f);
        }
    }
}
