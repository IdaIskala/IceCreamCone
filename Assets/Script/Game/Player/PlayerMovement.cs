using UnityEngine;

namespace Game
{
    /// <summary>
    /// Controlling the player movement
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        [Range(0.1f, 10f)]
        private float movementSpeed = 1f;

        [SerializeField]
        [Range(0.1f, 10f)]
        private float jumpForce = 1f;

        private Rigidbody2D player;

        private float movementDir;

        private bool onGround;

        private void Start()
        {
            player = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Move();
        }

        public void SetMovementDir(float dir)
        {
            movementDir = dir;
        }

        public void Jump()
        {
            if(onGround)
            {
                onGround = false;
                player.velocity = new Vector2(player.velocity.x, jumpForce);
            }
            
        }

        private void Move()
        {
            player.velocity = new Vector2(movementDir * movementSpeed, player.velocity.y);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            CheckGround(collision.gameObject);
        }

        private void CheckGround(GameObject other)
        {
            if(other.CompareTag("Ground"))
            {
                onGround = true;
            }
        }
    }
}
