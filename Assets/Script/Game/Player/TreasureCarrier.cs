using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class TreasureCarrier : MonoBehaviour
    {
        [SerializeField]
        private Player player;
        [SerializeField]
        private Transform treasureStackAnchor;
        [Range(0.1f,10f)]
        [SerializeField]
        private float stiffness = 2f;

        [Range(0.1f, 10f)]
        [SerializeField]
        private float maxSpeed = 2f;


        private void Update()
        {
            UpdateTreasureStack();
        }

        public void AddTreasure(Transform treasure)
        {
            AddTreasure(treasure, treasureStackAnchor);
        }

        public void AddTreasure(Transform treasure, Transform previous)
        {
            TreasureConnection connection = treasure.gameObject.AddComponent<TreasureConnection>();
            connection.ConnectItems(previous, treasure.transform, 1f, stiffness, stiffness);
        }

        private void UpdateTreasureStack()
        {
            // TODO: optimoi...
            foreach(Treasure treasure in player.Treasures)
            {
                TreasureConnection connection = treasure.gameObject.GetComponent<TreasureConnection>();
                connection.UpdateConnection();
            }
        }

    }

}
