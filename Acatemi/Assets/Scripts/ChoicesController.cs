using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicesController : MonoBehaviour
{
    private int currentTrueAnswer;
    [SerializeField] private ProgressBarController progressBarController;

    [SerializeField] private AudioClip failSound, successSound;
    [SerializeField] private GameObject confetti;
    [SerializeField] private GameObject exclamationMark;
    private float failSoundLength, successSoundLength;
    private void Start()
    {
        failSoundLength = failSound.length;
        successSoundLength = successSound.length;
    }
    public void UpdateCurrentTrueAnswer()
    {
        currentTrueAnswer = GameManager.instance.currentQuestion.trueAnswer;
    }
    public void ChoiceOneClicked()
    {
        ControlAnswer(1);
    }
    public void ChoiceTwoClicked()
    {
        ControlAnswer(2);
    }
    public void ChoiceThreeClicked()
    {
        ControlAnswer(3);
    }

    private void ControlAnswer(int v)
    {
        if (v == currentTrueAnswer)
        {
            Debug.Log("Doğru cevap");
            confetti.SetActive(true);
            progressBarController.UpdateProgressBar();
            StartCoroutine(DisableConfetti());
            HandlePassedSound();
        }
        else
        {
            Debug.Log("Yanlış cevap");
            HandleFailedSound();
            
        }
    }

    private IEnumerator DisableConfetti()
    {
        yield return new WaitForSeconds(1.5f);
        confetti.SetActive(false);
    }

    private void HandleFailedSound()
    {
        GameManager.instance.professorAudioSource.PlayOneShot(failSound);
        // Shake camera --- Exclamation mark animation
        PerformExclamationMarkAnimation();
        StartCoroutine(PlayFailedQuest());

    }

    private IEnumerator PlayFailedQuest()
    {
        GameManager.Questions currentQuestion = GameManager.instance.currentQuestion;
        AudioSource professorAudioSource = GameManager.instance.professorAudioSource;
        yield return new WaitForSeconds(failSoundLength);
        professorAudioSource.PlayOneShot(currentQuestion.failedAudio);
    }



    private void HandlePassedSound()
    {

        GameManager.instance.professorAudioSource.PlayOneShot(successSound);
        StartCoroutine(PlaySuccessQuest());
    }

    private IEnumerator PlaySuccessQuest()
    {

        GameManager.Questions currentQuestion = GameManager.instance.currentQuestion;
        AudioSource professorAudioSource = GameManager.instance.professorAudioSource;
        yield return new WaitForSeconds(successSoundLength);
        professorAudioSource.PlayOneShot(currentQuestion.passedAudio);
        StartCoroutine(HideQuestionPanel(currentQuestion.passedAudio.length));
    }

    private IEnumerator HideQuestionPanel(float audioLength)
    {
        yield return new WaitForSeconds(audioLength);
        GameManager.instance.questionPassed = true;
    }

    private void PerformExclamationMarkAnimation()
    {
        exclamationMark.SetActive(true);
        exclamationMark.transform.localScale = Vector3.zero;
        LeanTween.scale(exclamationMark, Vector3.one, 0.5f).setEaseOutBounce().setOnComplete(() =>
        {
            LeanTween.scale(exclamationMark, Vector3.zero, 0.5f).setEaseInBack().setDelay(0.5f).setOnComplete(() =>
            {
                exclamationMark.SetActive(false);
            });
        });
    }
}
