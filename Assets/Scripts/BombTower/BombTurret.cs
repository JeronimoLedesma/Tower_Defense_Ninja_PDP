using System.Collections;
using UnityEngine;

public class BombTurret : AbstractTowers
{
    protected override void Fire()
    {
        if (currentTarget != null)
        {
            Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            canFire = false;
            StartCoroutine(FireRateHandler());
        }
        
    }
}
