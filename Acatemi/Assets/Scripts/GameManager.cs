using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of GameManager found!");
            return;
        }
        instance = this;
    }
    #endregion

    public List<Questions> questions = new List<Questions>();
    [SerializeField] public AudioSource professorAudioSource;
    [SerializeField] private GameObject questionPanel;
    public class Questions
    {
        public string questionString;
        public AudioClip professorAudio, questionAudio, passedAudio, failedAudio;
        public Sprite choice1, choice2, choice3;
        public int trueAnswer;


        public Questions(string questionString, AudioClip proffesorQuest, AudioClip question, AudioClip passedAudio, AudioClip failedAudio, Sprite choice1, Sprite choice2, Sprite choice3, int trueAnswer)
        {
            this.questionString = questionString;
            this.professorAudio = proffesorQuest;
            this.questionAudio = question;
            this.passedAudio = passedAudio;
            this.failedAudio = failedAudio;
            this.choice1 = choice1;
            this.choice2 = choice2;
            this.choice3 = choice3;
            this.trueAnswer = trueAnswer;
        }


    }

    [HideInInspector] public Questions currentQuestion;
    [HideInInspector] public bool questionPassed = false;
    [SerializeField] private ChoicesController choicesController;
    [SerializeField] private QuestionManager questionManager;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private AudioClip professorMirnav, yaramazSarimsak , quest1, quest2, quest3;
    [SerializeField] private Animator cameraAnimator;
    [SerializeField] private GameObject _cam;

    private Vector3 camPos = new Vector3(-7.11f, 10.27f, 0.04f);
    private Vector3 camRot = new Vector3(15.066f, -90, 0);
    private void Start()
    {
        InitializeQuestions();
        Debug.Log(quest1.length + quest2.length + quest3.length);
        StartCoroutine(WaitForCinematic());
    }

    private IEnumerator WaitForCinematic()
    {
        yield return new WaitForSeconds(0.5f);

        professorAudioSource.PlayOneShot(professorMirnav);
        yield return new WaitForSeconds(4f);

        professorAudioSource.PlayOneShot(yaramazSarimsak);
        yield return new WaitForSeconds(4.6f);



        cameraAnimator.SetTrigger("StartCameraMotion");

        professorAudioSource.PlayOneShot(quest1);
        yield return new WaitForSeconds(quest1.length);

        professorAudioSource.PlayOneShot(quest2);
        yield return new WaitForSeconds(quest2.length);

        professorAudioSource.PlayOneShot(quest3);
        yield return new WaitForSeconds(quest3.length);


        // cameraAnimator.enabled = false;


        // _cam.transform.localPosition = camPos;
        // _cam.transform.localRotation = Quaternion.Euler(camRot);



        StartCoroutine(StartGame());
        questionPanel.SetActive(true);
        questionManager.UpdateQuestionUI(currentQuestion);
        choicesController.UpdateCurrentTrueAnswer();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void InitializeQuestions()
    {
        //1. Soru
        questions.Add(new Questions(questionString: "Bir fareyi yakalamanın en iyi yolu nedir?",
                                    proffesorQuest: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Professor1),
                                    question: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Question1),
                                    passedAudio: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Question1Passed),
                                    failedAudio: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Question1Failed),
                                    choice1: ImageHolder.instance.GetImage(ImageHolder.ImageEnum.Q1Choice1),
                                    choice2: ImageHolder.instance.GetImage(ImageHolder.ImageEnum.Q1Choice2),
                                    choice3: ImageHolder.instance.GetImage(ImageHolder.ImageEnum.Q1Choice3),
                                    trueAnswer: 1));
        //2. Soru
        questions.Add(new Questions(questionString: " İnsan köleni nasıl sinir edebilirsin?",
                                    proffesorQuest: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Professor2),
                                    question: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Question2),
                                    passedAudio: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Question2Passed),
                                    failedAudio: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Question2Failed),
                                    choice1: ImageHolder.instance.GetImage(ImageHolder.ImageEnum.Q2Choice1),
                                    choice2: ImageHolder.instance.GetImage(ImageHolder.ImageEnum.Q2Choice2),
                                    choice3: ImageHolder.instance.GetImage(ImageHolder.ImageEnum.Q2Choice3),
                                    trueAnswer: 1));
        //3. Soru
        questions.Add(new Questions(questionString: " Kedicikler nasıl temizlenir?",
                                    proffesorQuest: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Professor3),
                                    question: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Question3),
                                    passedAudio: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Question3Passed),
                                    failedAudio: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Question3Failed),
                                    choice1: ImageHolder.instance.GetImage(ImageHolder.ImageEnum.Q3Choice1),
                                    choice2: ImageHolder.instance.GetImage(ImageHolder.ImageEnum.Q3Choice2),
                                    choice3: ImageHolder.instance.GetImage(ImageHolder.ImageEnum.Q3Choice3),
                                    trueAnswer: 2));
        //4. Soru
        questions.Add(new Questions(questionString: " İnsanların dikkatini nasıl çekebiliriz?",
                                    proffesorQuest: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Professor4),
                                    question: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Question4),
                                    passedAudio: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Question4Passed),
                                    failedAudio: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Question4Failed),
                                    choice1: ImageHolder.instance.GetImage(ImageHolder.ImageEnum.Q4Choice1),
                                    choice2: ImageHolder.instance.GetImage(ImageHolder.ImageEnum.Q4Choice2),
                                    choice3: ImageHolder.instance.GetImage(ImageHolder.ImageEnum.Q4Choice3),
                                    trueAnswer: 1));
        //5. Soru        
        questions.Add(new Questions(questionString: "Uykumuz geldiğinde ne yaparız?",
                                    proffesorQuest: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Professor5),
                                    question: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Question5),
                                    passedAudio: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Question5Passed),
                                    failedAudio: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Question5Failed),
                                    choice1: ImageHolder.instance.GetImage(ImageHolder.ImageEnum.Q5Choice1),
                                    choice2: ImageHolder.instance.GetImage(ImageHolder.ImageEnum.Q5Choice2),
                                    choice3: ImageHolder.instance.GetImage(ImageHolder.ImageEnum.Q5Choice3),
                                    trueAnswer: 2));
        //6. Soru
        questions.Add(new Questions(questionString: "Karnımız acıktığında ne yapmalıyız?",
                                    proffesorQuest: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Professor6),
                                    question: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Question6),
                                    passedAudio: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Question6Passed),
                                    failedAudio: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Question6Failed),
                                    choice1: ImageHolder.instance.GetImage(ImageHolder.ImageEnum.Q6Choice1),
                                    choice2: ImageHolder.instance.GetImage(ImageHolder.ImageEnum.Q6Choice2),
                                    choice3: ImageHolder.instance.GetImage(ImageHolder.ImageEnum.Q6Choice3),
                                    trueAnswer: 2));
        //7. Soru
        questions.Add(new Questions(questionString: "İnsanlar uyurken ne yapmalıyız?",
                                    proffesorQuest: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Professor7),
                                    question: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Question7),
                                    passedAudio: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Question7Passed),
                                    failedAudio: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Question7Failed),
                                    choice1: ImageHolder.instance.GetImage(ImageHolder.ImageEnum.Q7Choice1),
                                    choice2: ImageHolder.instance.GetImage(ImageHolder.ImageEnum.Q7Choice2),
                                    choice3: ImageHolder.instance.GetImage(ImageHolder.ImageEnum.Q7Choice3),
                                    trueAnswer: 1));
        //8. Soru
        questions.Add(new Questions(questionString: "Kölemiz bize yemek verdiğinde ne yapmalıyız?",
                                    proffesorQuest: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Professor8),
                                    question: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Question8),
                                    passedAudio: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Question8Passed),
                                    failedAudio: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Question8Failed),
                                    choice1: ImageHolder.instance.GetImage(ImageHolder.ImageEnum.Q8Choice1),
                                    choice2: ImageHolder.instance.GetImage(ImageHolder.ImageEnum.Q8Choice2),
                                    choice3: ImageHolder.instance.GetImage(ImageHolder.ImageEnum.Q8Choice3),
                                    trueAnswer: 2));
        //9. Soru
        questions.Add(new Questions(questionString: "Isınmak için ne yapabiliriz?",
                                    proffesorQuest: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Professor9),
                                    question: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Question9),
                                    passedAudio: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Question9Passed),
                                    failedAudio: SoundHolder.instance.GetSound(SoundHolder.SoundEnum.Question9Failed),
                                    choice1: ImageHolder.instance.GetImage(ImageHolder.ImageEnum.Q9Choice1),
                                    choice2: ImageHolder.instance.GetImage(ImageHolder.ImageEnum.Q9Choice2),
                                    choice3: ImageHolder.instance.GetImage(ImageHolder.ImageEnum.Q9Choice3),
                                    trueAnswer: 1));

    }

    private IEnumerator StartGame()  // Game Logic is here
    {
        foreach (Questions question in questions)
        {
            Debug.Log("beginning of foreach");
            // UpdateQuestionUI(question);
            

            
            currentQuestion = question;
            float time = question.professorAudio.length;

            professorAudioSource.PlayOneShot(question.professorAudio);

            yield return new WaitForSeconds(time); // Wait until audio is finished


            AskQuestion(question);  // Enable question panel

            yield return new WaitUntil(() => questionPassed); // Wait until user selects correct answer
            // TODO : Update the code above to wait until user clicks a button, not any key // DONE

            // TODO : after user guests the true answer, play the correct sound and disable the question panel // DONE
            // TODO : after user guesses the wrong answer, play the wrong sound, panel stays open // DONE

            LeanTween.moveLocalX(questionPanel, Random.Range(0,2) == 1 ? -1000 : 1000, 0.5f).setEaseOutBounce();
        }
        Debug.Log("Questins are finished, game is over"); // TODO : Perform game over logic
        LeanTween.scale(gameOverPanel, Vector3.one, 0.5f).setEaseOutBounce();
    }

    private void AskQuestion(Questions question)
    {
        questionPassed = false;
        choicesController.UpdateCurrentTrueAnswer();
        questionManager.UpdateQuestionUI(question);

        professorAudioSource.PlayOneShot(question.questionAudio);
        LeanTween.moveLocalX(questionPanel, 0, 0.5f).setEaseOutBounce();
    }
}
