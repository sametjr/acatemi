using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject howToPlayPanel;
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ShowHowToPlay()
    {
        LeanTween.moveLocalX(howToPlayPanel, 0, 1f).setEaseOutBounce();

    }

    public void HideHowToPlay()
    {
        LeanTween.moveLocalX(howToPlayPanel, 1000, 1f).setEaseOutBounce();
    }
}
