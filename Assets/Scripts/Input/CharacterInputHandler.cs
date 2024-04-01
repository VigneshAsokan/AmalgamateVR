using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputHandler : MonoBehaviour
{
    Vector2 moveInput;
    Vector2 viewInput;

    bool isjumpPressed = false;
    CharacterMovementHandler characterMovementHandler;
    private void Awake()
    {
        characterMovementHandler = GetComponent<CharacterMovementHandler>();
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        viewInput.x = Input.GetAxis("Mouse X");
        viewInput.y = Input.GetAxis("Mouse Y") * -1;

        characterMovementHandler.setViewInputVector(viewInput);

        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        isjumpPressed = Input.GetButtonDown("Jump");
    }

    public NetworkInputData GetInputData()
    {
        NetworkInputData networkInputData = new NetworkInputData();
        networkInputData.MovementInput = moveInput;

        networkInputData.RotationInput = viewInput.x;
        
        networkInputData.isJumpPressed = isjumpPressed; 
        return networkInputData;
    }
}
