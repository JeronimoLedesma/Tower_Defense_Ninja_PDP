using System;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [SerializeField] private float currentGold;
    [SerializeField] private GameObject[] towerPrefabs;

    private int selectedTower = 0;

    public GameObject GetSelectedTower()
    {
        return towerPrefabs[selectedTower];
    }
}
