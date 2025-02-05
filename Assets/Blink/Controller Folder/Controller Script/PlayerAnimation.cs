using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaalChakra.FinalCharController
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator anim;

        private PlayerMoveInput playerMoveInput;
        private PlayerState _playerState;
        [SerializeField] private float movementBlendSpeed = 0.02f;

        private Vector3 currentBlendInput = Vector3.zero;
        private static int inputHashX = Animator.StringToHash("inputX");
        private static int inputHashY = Animator.StringToHash("inputY");
        private static int inputMagnitudeHash = Animator.StringToHash("inputMagnitude");


        private void Awake()
        {
            playerMoveInput = GetComponent<PlayerMoveInput>();
            _playerState = GetComponent<PlayerState>();
        }

        private void Update()
        {
            UpdateAnimationState();

        }
       

       private void UpdateAnimationState()
       {    
            bool isSprinting = _playerState.CurrentPlayerMovementState == PlayerMovementState.Sprinting;



            Vector2 inputTarget = isSprinting ? playerMoveInput.MovementInput * 1.5f : playerMoveInput.MovementInput;

            currentBlendInput = Vector3.Lerp(currentBlendInput, inputTarget, movementBlendSpeed * Time.deltaTime);

            anim.SetFloat(inputHashX, currentBlendInput.x);
            anim.SetFloat(inputHashY, currentBlendInput.y);
            anim.SetFloat(inputMagnitudeHash, currentBlendInput.magnitude);
       }


    }

}