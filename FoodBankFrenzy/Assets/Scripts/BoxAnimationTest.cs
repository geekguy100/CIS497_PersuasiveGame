using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAnimationTest : MonoBehaviour
{
    public bool isComplete;
    public Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        isComplete = false;
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isComplete)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                isComplete = true;
                animator.SetBool("isComplete", isComplete);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                isComplete = false;
                animator.SetBool("isComplete", isComplete);
            }
        }
        
    }
}
