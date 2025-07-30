using UnityEngine;

public class BombProjectile : Projectile
{
    [SerializeField] private GameObject explosion;
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        base.OnTriggerEnter2D(collision);
    }
}
