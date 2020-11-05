using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBase : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.levelStarted)
        {
            anim.enabled = true;
        }
    }
}
