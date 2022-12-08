using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float PosX;
    [SerializeField] private float PosZ;
    [SerializeField] private float speed;
    void Start()
    {
        characterController = transform.GetComponent<CharacterController>();
    }

    void Update()
    {
        PosX = Input.GetAxis("Horizontal");
        PosZ = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        characterController.Move(new Vector3(PosX, 0, PosZ) * speed * Time.deltaTime);
    }
}
