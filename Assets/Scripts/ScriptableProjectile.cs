using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableProjectile", menuName = "Scriptable Objects/ScriptableProjectile")]
public class ScriptableProjectile : ScriptableObject
{
    [SerializeField] private Sprite projectileSprite;
    [SerializeField] private float projectileDamage;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float projectileLifeTime;
    [SerializeField] private int projectilePierce;


    public Sprite GSProjectileSprite
    { get { return projectileSprite; } }
    public float GSProjectileDamage
    { get { return projectileDamage; } }
    public float GSProjectileSpeed
    { get { return projectileSpeed; } }
    public float GSProjectileLifeTime
    { get { return projectileLifeTime; } }
    public int GSProctilePierce
    { get { return projectilePierce; } }
}
