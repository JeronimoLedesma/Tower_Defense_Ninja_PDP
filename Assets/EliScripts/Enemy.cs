using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected float MoveSpeed;
    protected float MaxHealth;
    protected float CurrentHealth;
    protected float RewardValue;
    protected Rigidbody2D rb;
    protected Transform target;
    protected int pathIndex = 0;
    [SerializeField] ScriptableEnemy enemyTypeData;

    protected void Start()
    {
        MoveSpeed = enemyTypeData.MoveSpeed;
        MaxHealth = enemyTypeData.MaxHealth;
        RewardValue = enemyTypeData.RewardValue;
        target = LevelManager.MainInstance.pathPoints[0];
        rb =GetComponent<Rigidbody2D>();
    }
}
