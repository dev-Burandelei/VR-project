using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;
    public bool isClosed = true;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            isOpen = true;
            isClosed = false;
            animator.SetBool("open", true);
            animator.SetBool("close", false);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            isOpen = false;
            isClosed = true;
            animator.SetBool("open", false);
            animator.SetBool("close", true);
        }
    }
}
