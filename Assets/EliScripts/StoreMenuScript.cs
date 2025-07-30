using TMPro;
using UnityEngine;

public class StoreMenuScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyText;
    [SerializeField] Animator anim;

    private bool isOpen = true;

    public void onClickMenu()
    {
        isOpen = !isOpen;
        anim.SetBool("MenuOpen", isOpen);
    }
}
