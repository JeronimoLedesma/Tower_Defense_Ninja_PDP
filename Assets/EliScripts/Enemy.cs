using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float MoveSpeed;
    private float MaxHealth;
    private float CurrentHealth;
    private float Damage;
    private float RewardValue;
    private Rigidbody2D rb;
    private Transform target;
    private int pathIndex = 0;
    private bool isDestroyed = false;
    [SerializeField] ScriptableEnemy enemyTypeData;
    [SerializeField] private Animator anim;

    private void Start()
    {
        MoveSpeed = enemyTypeData.MoveSpeed;
        MaxHealth = enemyTypeData.MaxHealth;
        CurrentHealth = MaxHealth;
        Damage = enemyTypeData.Damage;
        RewardValue = enemyTypeData.RewardValue;
        target = LevelManager.MainInstance.pathPoints[0];
        rb =GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;

            if (pathIndex == LevelManager.MainInstance.pathPoints.Length)
            {
                EnemySpawner.onEnemyDestroy.Invoke();
                LevelManager.MainInstance.reduceLife(Damage);
                Destroy(gameObject);
                return;
            }
            else
            {
                target = LevelManager.MainInstance.pathPoints[pathIndex];
            }
        }

    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.linearVelocity = direction * MoveSpeed;

        if (direction.y < 0 && Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
        {
            anim.SetBool("IsDown", true);
            anim.SetBool("IsLeft", false);
            anim.SetBool("IsRight", false);
        }
        if (direction.y > 0 && Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
        {
            anim.SetBool("IsUp", true);
            anim.SetBool("IsLeft", false);
            anim.SetBool("IsRight", false);
        }
        if (direction.x < 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            anim.SetBool("IsLeft", true);
            anim.SetBool("IsUp", false);
            anim.SetBool("IsDown", false);
        }
        if (direction.x > 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            anim.SetBool("IsRight", true);
            anim.SetBool("IsUp", false);
            anim.SetBool("IsDown", false);
        }
    }

    public void TakeDamage(float dmg)
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
