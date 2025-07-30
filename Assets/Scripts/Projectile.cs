using Unity.IO.LowLevel.Unsafe;
using UnityEditor.Callbacks;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Sprite sprite;
    private float projectileDamage;
    private float projectileSpeed;
    private float projectileLifeTime;
    private float projectilePierce;

    private Rigidbody2D rb;
    [SerializeField] private ScriptableProjectile data;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        //Get Components
        rb = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        //Set Sctiptable Object
        sprite = data.GSProjectileSprite;
        projectileDamage = data.GSProjectileDamage;
        projectileSpeed = data.GSProjectileSpeed;
        projectileLifeTime = data.GSProjectileLifeTime;
        projectilePierce = data.GSProctilePierce;

        //Set Sprite
        spriteRenderer.sprite = sprite;
    }

    private void FixedUpdate()
    {
        //Move Projectile
        rb.AddForce(transform.right * projectileSpeed * Time.deltaTime);
    }
    private void Update()
    {
        //Destroy Projectile
        projectileLifeTime -= Time.deltaTime;
        if (projectileLifeTime <= 0) { Destroy(gameObject); }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //Reduce pierce on hit
        if (collision.gameObject.CompareTag("Enemy")) { projectilePierce--; }

        //Kill Projectile
        if (projectilePierce <= -1) { Destroy(gameObject); }

        //Damage Logic
    }
}
