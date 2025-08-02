using System.Collections;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    [SerializeField] GameObject tutorialText;
    [SerializeField] float timeToTrigger;


    private void Start()
    {
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(timeToTrigger);
        StartTutorial();
    }

    private void OnMouseDown()
    {
        FinishTutorial();
    }

    private void StartTutorial()
    {
        Time.timeScale = 0;
        tutorialText.SetActive(true);
    }

    public void FinishTutorial()
    {
        Time.timeScale = 1;
        tutorialText.SetActive(false);
    }
}
