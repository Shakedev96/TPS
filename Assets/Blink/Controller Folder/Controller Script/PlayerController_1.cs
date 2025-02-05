using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KaalChakra.FinalCharController
{
    [DefaultExecutionOrder (-1)] // will run before PlayerMoveInput Script.
    public class PlayerController_1 : MonoBehaviour
    {
        #region Class Variables

        [Header("Player Components")]
        [SerializeField] private CharacterController characterController;
        [SerializeField] private Camera playerCam;



        [Header("PLayer Movement Settings")]
        public float runAcceleration = 0.25f;
        public float runSpeed = 4f;
        public float sprintAcceleration = 0.5f;
        public float sprintSpeed = 7f;
        public float drag = 0.1f;
        public float movingThreshhold = 0.01f;




        [Header("Camera Settings")]

        // for camera settings
        public float lookSensH = 0.1f;
        public float lookSensV = 0.1f;
        public float lookLimitV = 89f;
        private Vector2 cameraRotation = Vector2.zero;
        private Vector2 playerTargetRotation = Vector2.zero;



        [Header("Other Components")]
        private PlayerMoveInput playerMoveInput;
        private PlayerState _playerState;

        #endregion
        

        #region StartUp Function
        private void Awake()
        {
            playerMoveInput = GetComponent<PlayerMoveInput>();
            _playerState = GetComponent<PlayerState>();
        }
        #endregion

        #region Update Logic and Other Functions
        private void Update()
        {
            UpdateMovementState();
            HandleLateralMovement();
            
        }
        


        //#region Player State UpdateFunction
        private void UpdateMovementState()
        {
            bool isMovementInput = playerMoveInput.MovementInput != Vector2.zero;
            bool isMovingLaterally = IsMovingLaterally();
            bool isSprinting = playerMoveInput.sprintToggleOn && isMovingLaterally;
            
            PlayerMovementState lateralState = isSprinting ? PlayerMovementState.Sprinting:
             isMovingLaterally || isMovementInput ? PlayerMovementState.Running : PlayerMovementState.Idle;
            _playerState.SetPlayerMovementState(lateralState);
        }
        

       
        private void HandleLateralMovement()
        {
            //reference for current State of player
            bool isSprinting = _playerState.CurrentPlayerMovementState == PlayerMovementState.Sprinting;

            // for state using Speed of Player states.
            
            float lateralAcceleration = isSprinting ? sprintAcceleration : runAcceleration;
            float clampLateralMagnitude = isSprinting ? sprintSpeed : runSpeed;
            
            Vector3 cameraForwardXZ = new Vector3(playerCam.transform.forward.x, 0f, playerCam.transform.forward.z).normalized;
            Vector3 cameraRightXZ  = new Vector3(playerCam.transform.right.x, 0f, playerCam.transform.right.z).normalized;

            Vector3 moveDirection = (cameraRightXZ * playerMoveInput.MovementInput.x) + (cameraForwardXZ * playerMoveInput.MovementInput.y);// movement of camera with respect ot player move direction.

            Vector3 moveDelta = moveDirection * lateralAcceleration;

            Vector3 newVelocity = characterController.velocity + moveDelta;

            // Adding the drag to the players movement

            Vector3 currentDrag = newVelocity.normalized * drag * Time.deltaTime;

            newVelocity = (newVelocity.magnitude > drag * Time.deltaTime) ? newVelocity - currentDrag : Vector3.zero; // to use drag to reduce velocity and acceleration. 

            //Clamping the new velocity so that the player does not move faster than it should
            newVelocity = Vector3.ClampMagnitude(newVelocity, clampLateralMagnitude);

            // Move Character, suggestion from Unity, calling this only once per frame
            characterController.Move(newVelocity * Time.deltaTime);

            Debug.Log("Player Speed is: " + newVelocity);
        }
        #endregion


        #region Late Update Logic
        
        private void LateUpdate()
        {
            cameraRotation.x += lookSensH * playerMoveInput.LookInput.x;
            cameraRotation.y = Mathf.Clamp(cameraRotation.y - (lookSensV * playerMoveInput.LookInput.y), -lookLimitV,lookLimitV);

            playerTargetRotation.x += transform.eulerAngles.x + lookSensH * playerMoveInput.LookInput.x;

            transform.rotation = Quaternion.Euler(0f, playerTargetRotation.x, 0f);

            playerCam.transform.rotation = Quaternion.Euler(cameraRotation.y, cameraRotation.x, 0f);
        }
        #endregion

        #region Player State Check
        private bool IsMovingLaterally()
        {
            Vector3 lateralVelocity = new Vector3 (characterController.velocity.x , 0f, characterController.velocity.y);

            return lateralVelocity.magnitude > movingThreshhold;
        }
        #endregion


    }
   
}
