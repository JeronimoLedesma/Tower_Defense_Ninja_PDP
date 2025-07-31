using System.Collections;
using UnityEngine;

public class ShurikenTurret : AbstractTowers
{
    protected override void Fire()
    {
        if (currentTarget != null)
        {
            StartCoroutine(ProjectileRandomizer());
            canFire = false;
            StartCoroutine(FireRateHandler());
        } 
    }

    private IEnumerator ProjectileRandomizer()
    {
        for (int i = 0; i < multishot; i++)
        {
            //Calculate Spread
            float spreadAngle = Random.Range(-25, 25);
            Quaternion spreadRotation = Quaternion.Euler(0, 0, spreadAngle);

            //Instantiate the projectiles with delay
            Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation * spreadRotation);
            yield return new WaitForSeconds(0.02f);
        }
    }
}
