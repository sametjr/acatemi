using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] private TMP_Text questionText;
    [SerializeField] private Image choice1, choice2, choice3;

    public void UpdateQuestionUI(GameManager.Questions question)
    {
        questionText.text = question.questionString;
        choice1.sprite = question.choice1;
        choice2.sprite = question.choice2;
        choice3.sprite = question.choice3;
    }
}
