using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    CharacterController controller;

    float speed = 5f;

    Vector3 vertical;
    Vector3 foward;
    Vector3 strafe;

    float gravity;
    float jumpSpeed = 3f;
    float maxJumpHeight = 2f;
    float timeToMaxJumpHeight = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        gravity = -2 * maxJumpHeight / Mathf.Pow(timeToMaxJumpHeight, 2);
        jumpSpeed = Mathf.Abs(gravity) * timeToMaxJumpHeight;
    }

    // Update is called once per frame
    void Update()
    {
        float fowardInput = Input.GetAxis("Vertical");
        float strafeInput = Input.GetAxis("Horizontal");

        foward = fowardInput * speed * transform.forward;
        strafe = strafeInput * speed * transform.right;

        vertical += gravity * Time.deltaTime * Vector3.up;

        if (controller.isGrounded)
        {
            vertical = Vector3.zero;

            if (Input.GetButtonDown("Jump"))
            {
                vertical = jumpSpeed * Vector3.up;
            }
        }

        Vector3 velocity = foward + strafe + vertical;

        controller.Move(velocity * Time.deltaTime);
    }
}
