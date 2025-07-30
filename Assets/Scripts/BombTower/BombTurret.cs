using System.Collections;
using UnityEngine;

public class BombTurret : AbstractTowers
{
    protected override void Fire()
    {
        Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        canFire = false;
        StartCoroutine(FireRateHandler());
    }

}
