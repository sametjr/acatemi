using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageHolder : MonoBehaviour
{
    #region Singleton
    public static ImageHolder instance;
    private void Awake() {
        if (instance != null) {
            Debug.LogWarning("More than one instance of ImageHolder found!");
            return;
        }
        instance = this;
    }
    #endregion
    
    [SerializeField] private Sprite q1choice1, q1choice2, q1choice3,
                                    q2choice1, q2choice2, q2choice3,
                                    q3choice1, q3choice2, q3choice3,
                                    q4choice1, q4choice2, q4choice3,
                                    q5choice1, q5choice2, q5choice3,
                                    q6choice1, q6choice2, q6choice3,
                                    q7choice1, q7choice2, q7choice3,
                                    q8choice1, q8choice2, q8choice3,
                                    q9choice1, q9choice2, q9choice3;

    public Dictionary<ImageEnum, Sprite> images = new Dictionary<ImageEnum, Sprite>();

    private void Start() {
        // Add images to dictionary
        images.Add(ImageEnum.Q1Choice1, q1choice1);
        images.Add(ImageEnum.Q1Choice2, q1choice2);
        images.Add(ImageEnum.Q1Choice3, q1choice3);

        images.Add(ImageEnum.Q2Choice1, q2choice1);
        images.Add(ImageEnum.Q2Choice2, q2choice2);
        images.Add(ImageEnum.Q2Choice3, q2choice3);

        images.Add(ImageEnum.Q3Choice1, q3choice1);
        images.Add(ImageEnum.Q3Choice2, q3choice2);
        images.Add(ImageEnum.Q3Choice3, q3choice3);

        images.Add(ImageEnum.Q4Choice1, q4choice1);
        images.Add(ImageEnum.Q4Choice2, q4choice2);
        images.Add(ImageEnum.Q4Choice3, q4choice3);

        images.Add(ImageEnum.Q5Choice1, q5choice1);
        images.Add(ImageEnum.Q5Choice2, q5choice2);
        images.Add(ImageEnum.Q5Choice3, q5choice3);

        images.Add(ImageEnum.Q6Choice1, q6choice1);
        images.Add(ImageEnum.Q6Choice2, q6choice2);
        images.Add(ImageEnum.Q6Choice3, q6choice3);

        images.Add(ImageEnum.Q7Choice1, q7choice1);
        images.Add(ImageEnum.Q7Choice2, q7choice2);
        images.Add(ImageEnum.Q7Choice3, q7choice3);

        images.Add(ImageEnum.Q8Choice1, q8choice1);
        images.Add(ImageEnum.Q8Choice2, q8choice2);
        images.Add(ImageEnum.Q8Choice3, q8choice3);

        images.Add(ImageEnum.Q9Choice1, q9choice1);
        images.Add(ImageEnum.Q9Choice2, q9choice2);
        images.Add(ImageEnum.Q9Choice3, q9choice3);
    }

    public Sprite GetImage(ImageEnum image)
    {
        return images[image];
    }

    public enum ImageEnum
    {
        Q1Choice1,
        Q1Choice2,
        Q1Choice3,

        Q2Choice1,
        Q2Choice2,
        Q2Choice3,

        Q3Choice1,
        Q3Choice2,
        Q3Choice3,

        Q4Choice1,
        Q4Choice2,
        Q4Choice3,

        Q5Choice1,
        Q5Choice2,
        Q5Choice3,

        Q6Choice1,
        Q6Choice2,
        Q6Choice3,

        Q7Choice1,
        Q7Choice2,
        Q7Choice3,

        Q8Choice1,
        Q8Choice2,
        Q8Choice3,

        Q9Choice1,
        Q9Choice2,
        Q9Choice3
    }
}
