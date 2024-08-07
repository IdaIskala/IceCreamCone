using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Player stores tresures
    /// </summary>
    public class Player : MonoBehaviour
    {

        private List<Treasure> treasures;
        public List<Treasure> Treasures {  get { return treasures; } }

        private void Awake()
        {
            treasures = new List<Treasure>();
        }

        public void AddTreasure(Treasure treasure)
        {
            treasures.Add(treasure);
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
