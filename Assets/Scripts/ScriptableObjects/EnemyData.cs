using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    public bool isDropping;
    public float hp;
    public float speed;
    public float shootingRange;
    public float shootingSpeed;

    public EnemyData(bool isLooting, float hp, float speed, float shootingRange, float shootingSpeed)
    {
        this.isDropping = isLooting;
        this.hp = hp;
        this.speed = speed;
        this.shootingRange = shootingRange;
        this.shootingSpeed = shootingSpeed;
    }
}

