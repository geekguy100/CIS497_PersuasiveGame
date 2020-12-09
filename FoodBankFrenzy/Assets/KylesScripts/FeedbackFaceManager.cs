/*****************************************************************************
// File Name :         FeedbackFaceManager.cs
// Author :            Kyle Grenier
// Creation Date :     12/9/2020
//
// Brief Description : Controls the feedback faces' behaviours, mainly animation.
*****************************************************************************/
using UnityEngine;

public class FeedbackFaceManager : Singleton<FeedbackFaceManager>
{
    private Animator[] animators;

    protected override void Awake()
    {
        base.Awake();

        //Find all of the game objects tagged "Face". Set the animator array to the length of the
        //found objects. Make sure all faces start off NOT happy (sad).
        GameObject[] feedbackFaces = GameObject.FindGameObjectsWithTag("Face");
        animators = new Animator[feedbackFaces.Length];

        for (int i = 0; i < feedbackFaces.Length; ++i)
        {
            animators[i] = feedbackFaces[i].GetComponent<Animator>();
            animators[i].SetBool("Happy", false);
        }
    }

    /// <summary>
    /// Animate the faces.
    /// </summary>
    /// <param name="isHappy">True if the faces are happy.</param>
    public void Animate(bool isHappy)
    {
        //If the faces are happy, play the happy anim. Else, play the sad anim.
        if (isHappy)
        {
            foreach (Animator animator in animators)
            {
                animator.SetBool("Happy", true);
                animator.SetTrigger("Happy_Anim");
            }
        }
        else
        {
            foreach (Animator animator in animators)
            {
                animator.SetBool("Happy", false);
                animator.SetTrigger("Sad_Anim");
            }
        }
    }
}