using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    
    /*void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;
            
            if (pathIndex == LevelManager.MainInstance.pathPoints.Length)
            {
                EnemySpawner.onEnemyDestroy.Invoke();
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
    }*/
}
