using System;
using TMPro;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [SerializeField] private float currentGold;
    [SerializeField] private Towers[] towerPrefabs;
    [SerializeField] TextMeshProUGUI currencyText;

    private int selectedTower = 0;

    private void OnGUI()
    {
        currencyText.text = LevelManager.MainInstance.currency.ToString();
    }

    public Towers GetSelectedTower()
    {
        return towerPrefabs[selectedTower];
    }

    public void SetSelectedTower(int _selectedTower)
    {
        selectedTower = _selectedTower;
    }
}
