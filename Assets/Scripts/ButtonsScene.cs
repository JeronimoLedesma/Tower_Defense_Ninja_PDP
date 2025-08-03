using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScene : MonoBehaviour
{
    [SerializeField] private int selectedScene;

    public void OnClick()
    {
        SceneManager.LoadScene(selectedScene);
    }
}
