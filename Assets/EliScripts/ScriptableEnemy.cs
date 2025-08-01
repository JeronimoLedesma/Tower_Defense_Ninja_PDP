using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableEnemy", menuName = "Enemy")]
public class ScriptableEnemy : ScriptableObject
{
    [SerializeField] private float movespeed;
    [SerializeField] private float maxhealth;
    [SerializeField] private int rewardvalue;

    public float MoveSpeed { get { return movespeed; } }
    public float MaxHealth { get { return maxhealth; } }
    public int RewardValue { get { return rewardvalue; } }
}
