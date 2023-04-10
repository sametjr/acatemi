using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHolder : MonoBehaviour
{
    #region Singleton
    public static SoundHolder instance;
    private void Awake() {
        if (instance != null) {
            Debug.LogWarning("More than one instance of SoundHolder found!");
            return;
        }
        instance = this;
    }
    #endregion
    [SerializeField] private AudioClip  q1prof, q1sound, q1Passed, q1Failed
                                       ,q2prof, q2sound, q2Passed, q2Failed
                                       ,q3prof, q3sound, q3Passed, q3Failed
                                       ,q4prof, q4sound, q4Passed, q4Failed
                                       ,q5prof, q5sound, q5Passed, q5Failed
                                       ,q6prof, q6sound, q6Passed, q6Failed
                                       ,q7prof, q7sound, q7Passed, q7Failed
                                       ,q8prof, q8sound, q8Passed, q8Failed
                                       ,q9prof, q9sound, q9Passed, q9Failed;

    public Dictionary<SoundEnum, AudioClip> sounds = new Dictionary<SoundEnum, AudioClip>();
    public enum SoundEnum
    {
        Professor1,
        Question1,
        Question1Passed,
        Question1Failed,


        Professor2,
        Question2,
        Question2Passed,
        Question2Failed,

        Professor3,
        Question3,
        Question3Passed,
        Question3Failed,

        Professor4,
        Question4,
        Question4Passed,
        Question4Failed,

        Professor5,
        Question5,
        Question5Passed,
        Question5Failed,

        Professor6,
        Question6,
        Question6Passed,
        Question6Failed,

        Professor7,
        Question7,
        Question7Passed,
        Question7Failed,

        Professor8,
        Question8,
        Question8Passed,
        Question8Failed,

        Professor9,
        Question9,
        Question9Passed,
        Question9Failed,

    }

    private void Start() {
        DontDestroyOnLoad(gameObject);
        // Add sounds to dictionary
        sounds.Add(SoundEnum.Professor1, q1prof);
        sounds.Add(SoundEnum.Question1, q1sound);
        sounds.Add(SoundEnum.Question1Passed, q1Passed);
        sounds.Add(SoundEnum.Question1Failed, q1Failed);

        sounds.Add(SoundEnum.Professor2, q2prof);
        sounds.Add(SoundEnum.Question2, q2sound);
        sounds.Add(SoundEnum.Question2Passed, q2Passed);
        sounds.Add(SoundEnum.Question2Failed, q2Failed);

        sounds.Add(SoundEnum.Professor3, q3prof);
        sounds.Add(SoundEnum.Question3, q3sound);
        sounds.Add(SoundEnum.Question3Passed, q3Passed);
        sounds.Add(SoundEnum.Question3Failed, q3Failed);

        sounds.Add(SoundEnum.Professor4, q4prof);
        sounds.Add(SoundEnum.Question4, q4sound);
        sounds.Add(SoundEnum.Question4Passed, q4Passed);
        sounds.Add(SoundEnum.Question4Failed, q4Failed);

        sounds.Add(SoundEnum.Professor5, q5prof);
        sounds.Add(SoundEnum.Question5, q5sound);
        sounds.Add(SoundEnum.Question5Passed, q5Passed);
        sounds.Add(SoundEnum.Question5Failed, q5Failed);

        sounds.Add(SoundEnum.Professor6, q6prof);
        sounds.Add(SoundEnum.Question6, q6sound);
        sounds.Add(SoundEnum.Question6Passed, q6Passed);
        sounds.Add(SoundEnum.Question6Failed, q6Failed);

        sounds.Add(SoundEnum.Professor7, q7prof);
        sounds.Add(SoundEnum.Question7, q7sound);
        sounds.Add(SoundEnum.Question7Passed, q7Passed);
        sounds.Add(SoundEnum.Question7Failed, q7Failed);

        sounds.Add(SoundEnum.Professor8, q8prof);
        sounds.Add(SoundEnum.Question8, q8sound);
        sounds.Add(SoundEnum.Question8Passed, q8Passed);
        sounds.Add(SoundEnum.Question8Failed, q8Failed);

        sounds.Add(SoundEnum.Professor9, q9prof);
        sounds.Add(SoundEnum.Question9, q9sound);
        sounds.Add(SoundEnum.Question9Passed, q9Passed);
        sounds.Add(SoundEnum.Question9Failed, q9Failed);
    }

    public AudioClip GetSound(SoundEnum sound)
    {
        return sounds[sound];
    }
}
