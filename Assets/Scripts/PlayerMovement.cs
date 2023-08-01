using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController playercontroller;
    private float movesped = 10f;
    public float runspeed = 10f;
    public float walkspeed = 5f;
    public float g;
    public Vector3 velociy;
    public LayerMask ground;
    public bool onGround;
    public Transform checkSpherePos;
    public float checkRadius;
    public float jumpHeight;
    public bool isWalking;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movesped = runspeed;
            isWalking = false;
        }
        else
        {
            movesped = walkspeed;
            isWalking = true;
        }

        onGround = Physics.CheckSphere(checkSpherePos.position, checkRadius, ground);

        velociy.y -= g * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && onGround == true)
        {
            velociy.y = jumpHeight;
        }
        playercontroller.Move(velociy);

        float x = Input.GetAxis("Horizontal") * movesped * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * movesped * Time.deltaTime;

        playercontroller.Move(transform.forward * y);
        playercontroller.Move(transform.right * x);

    }
}
