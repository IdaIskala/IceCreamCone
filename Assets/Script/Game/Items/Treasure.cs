using UnityEngine;

namespace Game
{
    /// <summary>
    /// the player collects treasures
    /// </summary>
    public class Treasure : Item
    {
        bool collected = false;

        private SpriteRenderer spriteRenderer;
        public SpriteRenderer SpriteRenderer {  get { return spriteRenderer; } }

        private void Start()
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        /// <summary>
        /// Add this treasure for player
        /// </summary>
        /// <param name="player"></param>
        public override void PlayerInteraction(Player player)
        {
            if(!collected)
            {
                player.AddTreasure(this);
                collected = true;
            }
        }

    }
}
