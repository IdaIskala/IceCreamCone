using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Game
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private TreasureCarrier carrier;

        private List<Treasure> treasures;
        public List<Treasure> Treasures {  get { return treasures; } }

        private void Awake()
        {
            treasures = new List<Treasure>();
        }

        public void AddTreasure(Treasure treasure)
        {
            treasures.Add(treasure);
            GameLogger.Log("collect treasure");

            if(treasures.Count > 1)
            {
                carrier.AddTreasure(treasure.transform, treasures[treasures.Count - 2].transform);
            } 
            else
            {
                carrier.AddTreasure(treasure.transform);
            }
        }

        public void RemoveTreasure()
        {
            if(treasures.Count > 0)
            {
                Treasure treasure = treasures[treasures.Count - 1];
                treasures.RemoveAt(treasures.Count - 1);
                Destroy(treasure.gameObject);
            }
        }
    }
}
