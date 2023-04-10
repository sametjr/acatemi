using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressBarController : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Image progressBarInner;
    [SerializeField] private Image progressCat;
    [SerializeField] private TMP_Text progressText;

    public int currentQuestionIndex = 0;

    private IEnumerator Start()
    {
        progressBarInner.fillAmount = 0;
        yield return new WaitForSeconds(0.1f);
        UpdateProgressBar();
    }

    public void UpdateProgressBar()
    {
        progressBarInner.fillAmount = (float)currentQuestionIndex / GameManager.instance.questions.Count;

        progressCat.rectTransform.localPosition = new Vector3((progressBarInner.fillAmount * progressBarInner.rectTransform.rect.width - 3.33f), progressCat.rectTransform.rect.y - 1f, 0);
        




        if (currentQuestionIndex == GameManager.instance.questions.Count)
        {
            progressText.text = "10 / 10 :)";
        }
        else
        {
            progressText.text = currentQuestionIndex + "/" + GameManager.instance.questions.Count;
        }

        currentQuestionIndex++;
    }
}
