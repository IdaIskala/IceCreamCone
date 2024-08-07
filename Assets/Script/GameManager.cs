using System;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    /// <summary>
    /// Keeps track of all levels and current level
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager manager;
        public static Action<LevelType> OnLevelSelected;

        [SerializeField]
        private List<LevelType> levels;
        public List<LevelType> Levels { get { return levels; } }

        [SerializeField]
        private LevelType selectedLevel; //can contain default level for editor testing purposes
        public LevelType SelectedLevel { get { return selectedLevel; } }

        private void Awake()
        {
            if(manager == null)
            {
                manager = this;
            } else
            {
                Destroy(this.gameObject);
            }
        }

        private void OnEnable()
        {
            OnLevelSelected += SelectLevel;
        }

        private void OnDisable()
        {
            OnLevelSelected -= SelectLevel;
        }

        private void SelectLevel(LevelType level)
        {
            selectedLevel = level;
        }
    }
}
