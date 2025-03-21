using UnityEngine;
using UnityEngine.InputSystem;

// Joa

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack instance;

    [Header("Normal Attack")]
    [SerializeField] private GameObject normalAttack1Prefab;
    [SerializeField] private GameObject normalAttack2Prefab;
    [SerializeField] private GameObject normalAttack3Prefab;

    [SerializeField] private float normalAttack1Cooldown;
    [SerializeField] private float normalAttack2Cooldown;
    [SerializeField] private float normalAttack3Cooldown;

    [SerializeField] private float comboCooldown;
    [SerializeField] private float normalAttackDontMoveTime;

    [Header("Range Attack")]
    [SerializeField] private GameObject croissantPrefab;
    [SerializeField] private float croissantLifespan;

    [SerializeField] private float rangeAttackCooldown;

    [SerializeField] private float rangeAttackDontMoveTime;

    [Header("Assign")]
    [SerializeField] private Transform direction;
    [SerializeField] private Transform rangeSpawn;

    private bool isNormalAttacking;
    private float lastNormalAttackTimer;
    private int currentNormalAttack;
    

    private bool isRangeAttacking;
    private float lastRangeAttackTimer;

    private PlayerMovement movement;

    private void Awake()
    {
        instance = this;
        movement = PlayerMovement.instance;
    }

    private void FixedUpdate()
    {
        lastNormalAttackTimer -= Time.fixedDeltaTime;  //timers for cooldowns
        lastRangeAttackTimer -= Time.fixedDeltaTime;

        if (lastNormalAttackTimer <= 0)
        {
            isNormalAttacking = false;
        }

        if (lastRangeAttackTimer <= 0)
        {
            isRangeAttacking = false;
        }
    }

    public void RangeAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (lastRangeAttackTimer <= 0 && !movement.isDashing)
            {
                isRangeAttacking = true;
                lastRangeAttackTimer = rangeAttackCooldown;

                GameObject currentAttack = Instantiate(croissantPrefab, rangeSpawn.transform.position, Quaternion.identity);
                currentAttack.transform.forward = direction.forward;
                Destroy(currentAttack, croissantLifespan);
            }
        }
    }


    public void NormalAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

            if (lastNormalAttackTimer <=0 && !movement.isDashing)
            {
                isNormalAttacking = true;

                //change the attack index for combo
                if (lastNormalAttackTimer < -comboCooldown)  
                {
                    currentNormalAttack = 1;
                }
                else
                {
                    if (currentNormalAttack != 3)
                    {
                        currentNormalAttack++;
                    }
                    else
                    {
                        currentNormalAttack = 1;
                    }
                }

                SpawnNormalAttack(currentNormalAttack); // spawn attack depending on index
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
                lastNormalAttackTimer = normalAttack1Cooldown;
                break;

            case 2:
                currentAttack = Instantiate(normalAttack2Prefab, transform.position, Quaternion.identity);
                lastNormalAttackTimer = normalAttack2Cooldown;
                break;

            case 3:
                currentAttack = Instantiate(normalAttack3Prefab, transform.position, Quaternion.identity);
                lastNormalAttackTimer = normalAttack3Cooldown;
                break;

            default:
                currentAttack = Instantiate(normalAttack1Prefab, transform.position, Quaternion.identity);
                break;
        }

        currentAttack.transform.forward = direction.forward;
        Destroy(currentAttack, lastNormalAttackTimer);
    }
}
