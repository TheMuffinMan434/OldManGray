using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{

    [SerializeField] float walkSpeed;
    [SerializeField] float sprintSpeed;
    [SerializeField] float crouchSpeed;
    [SerializeField] float gravity = -13.0f;
    [SerializeField] [Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    float velocityY = 0.0f;
    public static Rigidbody rb;
    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;
    public bool isCrouched;
    public static bool isSprinting;
    public GameObject player;
    public float speed;

    CharacterController controller = null;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        isCrouched = false;
        isSprinting = false;
    }
    void Update()
    {
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        if (controller.isGrounded)
        {
            velocityY = 0.0f;
        }


        velocityY += gravity * Time.deltaTime;

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * speed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Crouch();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        if(!isSprinting && !isCrouched)
        {
            speed = walkSpeed;
        }
        else if (isSprinting && isCrouched)
        {
            speed = (sprintSpeed + crouchSpeed) / 2;
        }
        else if (isSprinting && !isCrouched)
        {
            speed = sprintSpeed;
        }
        else if(!isSprinting && isCrouched)
        {
            speed = crouchSpeed;
        }
    }

    public void Crouch()
    {
        if (isCrouched)
        {
            player.transform.localScale += new Vector3(0f, 0.5f, 0f);
            speed = walkSpeed;
            isCrouched = false;
        }
        else
        {
            player.transform.localScale -= new Vector3(0f, 0.5f, 0f);
            speed = crouchSpeed;
            isCrouched = true;
        }
    }
}
