using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class AbstractTowers : MonoBehaviour
{
    #region Variables

    //Stats
    protected string towerName;
    protected float RPS;
    protected float attackRange;
    protected int multishot;
    protected float rotationSpeed;
    protected bool canFire;
    protected float price;
    protected CircleCollider2D range;
    [SerializeField] protected string[] targetPriority;

    [Header("Links")]
    [SerializeField] protected ScriptableTowers Data;
    [SerializeField] protected Transform rotationPoint;
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected Transform projectileSpawnPoint;

    protected List<GameObject> enemiesInRange = new List<GameObject>();
    protected GameObject currentTarget;

    #endregion

    protected virtual void Start()
    {
        //Setup ScriptableObject
        towerName = Data.GSTowerName;
        RPS = Data.GSAttackSpeed;
        attackRange = Data.GSAttackRange;
        multishot = Data.GSMultishot;
        rotationSpeed = Data.GSRotationSpeed;
        price = Data.GSPrice;
        projectilePrefab = Data.GSProjectilePrefab;
        /*range.radius = attackRange;*/


        canFire = true;
    }

    protected virtual void Update()
    {
        //Constantly Find Correct Target
        currentTarget = FindTarget();

        // Track enemy and attack when posible
        Aim();
        if (canFire) { Fire(); }
    }

    #region Attacking

    protected virtual void Aim()
    {
        if (currentTarget == null) { return; }
        else
        {
            //Calculate direction
            Vector2 lookDirection = currentTarget.transform.position - transform.position;

            //Calculate angle
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

            //Apply rotation
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

    protected abstract void Fire();

    protected virtual IEnumerator FireRateHandler()
    {
        //Calculate Cooldown
        float CD = 1 / RPS;
        yield return new WaitForSeconds(CD);
        canFire = true;
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
                //Failsafe
                if (enemy == null) { continue; }

                //Get Distance to target
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
