using System;
using TMPro;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public static float payment = 100;
    [SerializeField] private GameObject[] towerPrefabs;
    [SerializeField] TextMeshProUGUI currencyText;

    private int selectedTower = 0;

    public GameObject GetSelectedTower()
    {
        return towerPrefabs[selectedTower];
    }

    public void SetSelectedTower(int _selectedTower)
    {
        selectedTower = _selectedTower;
        
    }
    public void SetPrice(float amountToPay)
    {
        payment = amountToPay;
    }

    private void OnGUI()
    {
        currencyText.text = LevelManager.MainInstance.currency.ToString();
    }
}
