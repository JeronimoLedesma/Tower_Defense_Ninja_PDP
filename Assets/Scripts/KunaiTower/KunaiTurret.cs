using UnityEngine;

public class KunaiTurret : AbstractTowers
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
