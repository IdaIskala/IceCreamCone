using UnityEngine;


namespace Game
{
    /// <summary>
    /// Items interact with player when collided
    /// </summary>
    public abstract class Item : MonoBehaviour
    {
        public abstract void PlayerInteraction(Player player);


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                CollidePlayer(collision.gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                CollidePlayer(collision.gameObject);
            }
        }

        private void CollidePlayer(GameObject playerObj)
        {
            Player player = playerObj.GetComponent<Player>();
            PlayerInteraction(player);
        }

    }
}

