using UnityEngine;

public class KunaiTurret : AbstractTowers
{
    protected override void Fire()
    {
        Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        canFire = false;
        StartCoroutine(FireRateHandler());
    }
}
