using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager MainInstance;

    public Transform startPoint;
    public Transform[] pathPoints;
    public int currency;

    private void Awake()
    {
        MainInstance = this;
    }

    private void Start()
    {
        currency = 100;
    }

    public void increasecurrency(int amount) { currency += amount; }

    public bool decreasecurrency(int amount) 
    {
        if (currency >= amount)
        {
            currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("No te alcanza la plata");
            return false;
        }

    }
}
