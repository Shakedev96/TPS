using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaalChakra.FinalCharController
{
    public class PlayerState : MonoBehaviour
    {
        [field: SerializeField] public PlayerMovementState CurrentPlayerMovementState {get; private set;} = PlayerMovementState.Idle;

        public void SetPlayerMovementState(PlayerMovementState playerMovementState)
        {
            CurrentPlayerMovementState = playerMovementState;
        }
        
    }
    public enum PlayerMovementState
        {
            Idle = 0,
            Walking = 1,
            Running = 2,
            Sprinting = 3,
            Jumping = 4,
            Falling = 5, 
            Strafing =6,
        }

        
}

