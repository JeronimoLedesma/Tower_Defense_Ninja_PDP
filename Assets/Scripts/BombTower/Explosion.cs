using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float explosionDamage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Damage Logic


            StartCoroutine(DestroyExplosion());
        }
    }

    private IEnumerator DestroyExplosion()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
