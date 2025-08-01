using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected float MoveSpeed;
    protected float MaxHealth;
    protected float CurrentHealth;
    protected int RewardValue;
    protected Rigidbody2D rb;
    protected Transform target;
    protected int pathIndex = 0;
    protected bool isDestroyed = false;
    [SerializeField] ScriptableEnemy enemyTypeData;

    protected void Start()
    {
        MoveSpeed = enemyTypeData.MoveSpeed;
        MaxHealth = enemyTypeData.MaxHealth;
        CurrentHealth = MaxHealth;
        RewardValue = enemyTypeData.RewardValue;
        target = LevelManager.MainInstance.pathPoints[0];
        rb =GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int dmg)
    {
        CurrentHealth -= dmg;
        if (CurrentHealth <= 0 && !isDestroyed)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            LevelManager.MainInstance.increasecurrency(RewardValue);
            isDestroyed = true;
            Destroy(gameObject);
        }
    }
}
