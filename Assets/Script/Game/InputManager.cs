using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    public class InputManager : MonoBehaviour
    {
        [HideInInspector]
        public PlayerMovement playerMovement;

        public void OnMove(InputAction.CallbackContext context)
        {
            Vector2 movementInput = context.ReadValue<Vector2>();

            playerMovement.SetMovementDir(movementInput.x);
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if(context.started)
            {
                playerMovement.Jump();
            }
        }
    }
}

