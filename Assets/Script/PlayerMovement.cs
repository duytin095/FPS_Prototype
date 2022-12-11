using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Animator animator;
    [SerializeField] private float PosX;
    [SerializeField] private float PosZ;
    [SerializeField] private float speed;
    [SerializeField] private string movingState = "isMove";
    void Start()
    {
        characterController = transform.GetComponent<CharacterController>();
        animator = transform.GetComponent<Animator>();
    }

    void Update()
    {
        PosX = Input.GetAxis("Horizontal");
        PosZ = Input.GetAxis("Vertical");

        if(PosX != 0 || PosZ != 0)
        {
            animator.SetBool(movingState, true);
        }
        else
        {
            animator.SetBool(movingState, false);
        }
    }

    private void FixedUpdate()
    {
        characterController.Move(new Vector3(PosX, 0, PosZ) * speed * Time.deltaTime);
    }
}
