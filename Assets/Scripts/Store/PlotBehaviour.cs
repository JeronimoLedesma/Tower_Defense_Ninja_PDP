using UnityEngine;

public class PlotBehaviour : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    [SerializeField] private StoreManager StoreManager;

    private GameObject tower;
    private Color startColor;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        startColor = sr.color;
    }

    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    private void OnMouseDown()
    {
        if (tower != null) { return; }
        else
        {
            tower = StoreManager.GetSelectedTower();
            if (LevelManager.MainInstance.decreasecurrency(StoreManager.payment))
            {
                Instantiate(tower, transform.position, Quaternion.identity);
            }
        }
    }
}
