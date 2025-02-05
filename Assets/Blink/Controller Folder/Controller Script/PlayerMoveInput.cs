using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KaalChakra.FinalCharController
{
    [DefaultExecutionOrder(-2)] // it will run before other scritps.
    public class PlayerMoveInput : MonoBehaviour, PlayerControls.IPlayerLocomotionMapActions
    {

        [SerializeField] private bool holdToSprint = true;
        public bool sprintToggleOn;
        public PlayerControls PlayerControls {get; private set;}


        public Vector2 MovementInput {get; private set;}

        public Vector2 LookInput { get; private set;}

        void OnEnable()
        {
            PlayerControls = new PlayerControls();
            PlayerControls.Enable();


            PlayerControls.PlayerLocomotionMap.Enable();
            PlayerControls.PlayerLocomotionMap.SetCallbacks(this);

        }
        
        void OnDisable()
        {
            PlayerControls.PlayerLocomotionMap.Disable();
            PlayerControls.PlayerLocomotionMap.RemoveCallbacks(this);
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            MovementInput = context.ReadValue<Vector2>();
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            LookInput = context.ReadValue<Vector2>();
        }

        public void OnToggleSprint(InputAction.CallbackContext context)
        {
            if(context.performed)
            {
                sprintToggleOn = holdToSprint || !sprintToggleOn;
            }
            else if(context.canceled)
            {
                sprintToggleOn = !holdToSprint && sprintToggleOn;
            }
        }
    }
}