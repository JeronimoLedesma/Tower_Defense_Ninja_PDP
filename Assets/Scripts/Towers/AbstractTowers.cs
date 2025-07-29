using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractTowers : MonoBehaviour
{
    #region Variables

    //Stats
    protected string towerName;
    protected float RPS;
    protected float attackRange;
    protected bool CanFire;
    protected float price;
    protected string targetPriority;

    [Header("Links")]
    [SerializeField] protected ScriptableTowers Data;
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected Transform projectileSpawnPoint;

    [SerializeField] protected List<GameObject> enemiesInRange = new List<GameObject>();
    protected GameObject currentTarget;

    #endregion

    protected virtual void Start()
    {
        //Setup ScriptableObject
        towerName = Data.GSTowerName;
        RPS = Data.GSAttackSpeed;
        attackRange = Data.GSAttackRange;
        price = Data.GSPrice;

        CanFire = true;
    }

    protected void Update()
    {
        currentTarget = FindTarget();
    }

    #region Attacking

    protected virtual void Fire()
    {
        Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
    }

    protected virtual IEnumerator FireRateHandler()
    {
        //Calculate Cooldown
        float CD = 1 / RPS;
        yield return new WaitForSeconds(CD);
        CanFire = true;
    }

    #endregion

    #region Targret Aquiring
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
            currentTarget = FindTarget();
        }
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
            currentTarget = FindTarget();
        }
    }

    protected GameObject FindTarget()
    {
        //Declare Variables
        GameObject closestEnemy = null;
        float minDistance = float.MaxValue;

        if (enemiesInRange == null) { return null; }
        else
        {
            foreach (GameObject enemy in enemiesInRange)
            {

                if (enemy == null) { continue; }

                float distanceToTarget = Vector3.Distance(gameObject.transform.position, enemy.transform.position);

                //Compare Distance
                if (distanceToTarget < minDistance)
                {
                    minDistance = distanceToTarget;
                    closestEnemy = enemy;
                }
            }
        }

        return closestEnemy;
    }

    #endregion
}
