using UnityEngine;


namespace Game
{
    public class Enemy : Item
    {
        /// <summary>
        /// Remove 1 treasure from player
        /// </summary>
        /// <param name="player"></param>
        public override void PlayerInteraction(Player player)
        {
            player.RemoveTreasure();
        }
    }

}
