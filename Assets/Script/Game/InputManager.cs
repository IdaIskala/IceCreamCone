using UnityEngine;
using UnityEngine.InputSystem;
using Utility;

namespace Game
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField]
        private PlayerMovement movement;

        public void OnMove(InputAction.CallbackContext context)
        {
            Vector2 movementInput = context.ReadValue<Vector2>();

            movement.SetMovementDir(movementInput.x);
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if(context.started)
            {
                movement.Jump();
            }
        }
    }
}

