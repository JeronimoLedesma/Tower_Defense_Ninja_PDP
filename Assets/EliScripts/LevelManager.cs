using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager MainInstance;

    public Transform startPoint;
    public Transform[] pathPoints;
    

    private void Awake()
    {
        MainInstance = this;
    }
}
