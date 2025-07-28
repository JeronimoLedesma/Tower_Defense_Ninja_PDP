using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableTowers", menuName = "Scriptable Objects/ScriptableTowers")]
public class ScriptableTowers : ScriptableObject
{
    [SerializeField] private string towerName;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackDamage;
    [SerializeField] private float price;


    public string GSTowerName
    { get { return towerName; } }
    public float GSAttackSpeed
    { get { return attackSpeed; } }
    public float GSAttackRange
    { get { return attackRange; } }
    public float GSAttackDamage
    { get { return attackDamage; } }
    public float GSPrice
        { get { return price; } }
}
