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

        [SerializeField]
        [Range(10f, 500f)]
        private float rotationSpeed = 150f; //player rotates to the opposite direction of the movement

        [SerializeField]
        [Range(0f, 90f)]
        private float maxRotation = 35f; //player rotates to the opposite direction of the movement

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
            UpdatePlayerRotation();
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

        //rotate player when moving
        private void UpdatePlayerRotation()
        {
            float rotationPercent = player.velocity.x / movementSpeed;

            float rotation = rotationPercent * maxRotation;

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 0f, rotation), rotationSpeed * Time.deltaTime);
        }
    }
}
