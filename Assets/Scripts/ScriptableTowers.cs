using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableTowers", menuName = "Scriptable Objects/ScriptableTowers")]
public class ScriptableTowers : ScriptableObject
{
    [SerializeField] private string towerName;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackRange;
    [SerializeField] private int multishot;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float price;


    public string GSTowerName
    { get { return towerName; } }
    public GameObject GSProjectilePrefab
    { get { return projectilePrefab; } }
    public float GSAttackSpeed
    { get { return attackSpeed; } }
    public float GSAttackRange
    { get { return attackRange; } }
    public float GSPrice
    { get { return price; } }
    public int GSMultishot
    { get { return multishot; } }
    public float GSRotationSpeed
    { get { return rotationSpeed; } }
        
}
