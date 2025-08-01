using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager MainInstance;

    public Transform startPoint;
    public Transform[] pathPoints;
    public float currency;


    private void Awake()
    {
        MainInstance = this;
    }

    private void Start()
    {
        currency = 100;
    }

    public void increasecurrency(float amount) { currency += amount; }

    public bool decreasecurrency(float amount)
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
