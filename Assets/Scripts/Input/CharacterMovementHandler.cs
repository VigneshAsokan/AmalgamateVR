using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using System;

public class CharacterMovementHandler : NetworkBehaviour
{
    Vector2 viewInput;

    //Rotation
    float CameraRotationX = 0;
    NetworkCharacterControllerPrototypeCustom networkControllerPrototypeCustom;
    Camera localCamera;
    private void Awake()
    {
        networkControllerPrototypeCustom = GetComponent<NetworkCharacterControllerPrototypeCustom>();
        localCamera = GetComponentInChildren<Camera>();
    }
    private void Update()
    {
        CameraRotationX += viewInput.y * Time.deltaTime * networkControllerPrototypeCustom.verticalRotationSpeed;
        CameraRotationX = Mathf.Clamp(CameraRotationX, -90, 90);

        localCamera.transform.localRotation = Quaternion.Euler(CameraRotationX, 0, 0);
    }
    public override void FixedUpdateNetwork()
    {
        base.FixedUpdateNetwork();
        if(GetInput( out NetworkInputData networkInputData))
        {
            networkControllerPrototypeCustom.Rotate(networkInputData.RotationInput);

            Vector3 moveDirection = transform.forward * networkInputData.MovementInput.y + transform.right * networkInputData.MovementInput.x;
            moveDirection.Normalize();

            networkControllerPrototypeCustom.Move(moveDirection);

            //jump
            if (networkInputData.isJumpPressed)
                networkControllerPrototypeCustom.Jump();
        
        }    
    }

    public  void setViewInputVector(Vector2 viewInput)
    {
        this.viewInput = viewInput;  
    }
}
