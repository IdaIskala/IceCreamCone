using UnityEngine;


namespace Game
{
    /// <summary>
    /// stores data of a single level
    /// </summary>
    [CreateAssetMenu(fileName = "LevelType", menuName = "ScriptableObjects/LevelType")]
    public class LevelType : ScriptableObject
    {
        public GameObject levelPrefab;
    }
}

