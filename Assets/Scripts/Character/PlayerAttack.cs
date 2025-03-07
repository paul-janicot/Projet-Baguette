using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject normalAttack1Prefab;
    [SerializeField] private GameObject normalAttack2Prefab;
    [SerializeField] private GameObject normalAttack3Prefab;

    [SerializeField] private float attack1Cooldown;
    [SerializeField] private float attack2Cooldown;
    [SerializeField] private float attack3Cooldown;

    [SerializeField] private float comboCooldown;

    [SerializeField] private Transform Direction;

    private bool isAttacking;

    private float lastAttackTimer;
    private int currentAttack;

    private bool attackPressedEarly;
    private bool fakePerformed;

    private void FixedUpdate()
    {
        lastAttackTimer -= Time.fixedDeltaTime;

        if (lastAttackTimer <= 0)
        {
            isAttacking = false;
        }
    }

    public void NormalAttack(InputAction.CallbackContext context)
    {
        if (context.performed || fakePerformed)
        {
            if (!isAttacking && lastAttackTimer <=0)
            {
                if (lastAttackTimer < -comboCooldown)
                {
                    currentAttack = 1;
                }
                else
                {
                    if (currentAttack != 3)
                    {
                        currentAttack++;
                    }
                    else
                    {
                        currentAttack = 1;
                    }
                }

                SpawnNormalAttack(currentAttack);
            }
        }
    }

    private void SpawnNormalAttack(int attack)
    {
        GameObject currentAttack;

        switch (attack)
        {
            case 1:
                currentAttack = Instantiate(normalAttack1Prefab, transform.position, Quaternion.identity);
                lastAttackTimer = attack1Cooldown;
                break;

            case 2:
                currentAttack = Instantiate(normalAttack2Prefab, transform.position, Quaternion.identity);
                lastAttackTimer = attack2Cooldown;
                break;

            case 3:
                currentAttack = Instantiate(normalAttack3Prefab, transform.position, Quaternion.identity);
                lastAttackTimer = attack3Cooldown;
                break;

            default:
                currentAttack = Instantiate(normalAttack1Prefab, transform.position, Quaternion.identity);
                break;
        }

        currentAttack.transform.forward = Direction.forward;
        Destroy(currentAttack, lastAttackTimer);
    }
}
