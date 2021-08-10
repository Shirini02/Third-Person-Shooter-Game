using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    public float playerMoveSpeed;

    [SerializeField]
    private float turnSpeed;
    Animator anim;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        var horizontalMovement = Input.GetAxis("Horizontal");
        var verticalMovement = Input.GetAxis("Vertical");

        var playerMovement = new Vector3(horizontalMovement, 0, verticalMovement);
        characterController.SimpleMove(playerMovement * Time.deltaTime * playerMoveSpeed);
        anim.SetFloat("Speed",playerMovement.magnitude);

        Quaternion newDirection = Quaternion.LookRotation(playerMovement);
        transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * turnSpeed);
    }
}
