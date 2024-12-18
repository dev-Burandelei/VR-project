using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;
    public ButtonInteract buttonInteract;
    private Animator animator;




    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("close", true);
        animator.SetBool("open", false);

    }

    // Update is called once per frame
    void Update()
    {
        isOpen = buttonInteract.isPressed;



        if (isOpen)
        {
            animator.SetBool("open", true);
            animator.SetBool("close", false);

        }
        else
        {
            animator.SetBool("close", true);
            animator.SetBool("open", false);
        }


    }
}
