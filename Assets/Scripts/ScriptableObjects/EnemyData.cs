using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    public bool isDropping;
    public float hp;

    public EnemyData(bool isLooting, float hp)
    {
        this.isDropping = isLooting;
        this.hp = hp;
    }
}

