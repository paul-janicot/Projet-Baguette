using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    public bool isDropping;
    public float hp;
    public float speed;
    public float shootingRange;

    public EnemyData(bool isLooting, float hp, float speed, float shootingRange)
    {
        this.isDropping = isLooting;
        this.hp = hp;
        this.speed = speed;
        this.shootingRange = shootingRange;
    }
}

