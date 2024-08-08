using UnityEngine;

namespace Game
{
    /// <summary>
    /// Instantiate selected level at the beginning of the game
    /// </summary>
    public class LevelInitializer : MonoBehaviour
    {
        private void Start()
        {
            InitializeLevel();
        }

        private void InitializeLevel()
        {
            GameObject level = Instantiate(GameManager.manager.SelectedLevel.levelPrefab);

            //set input and player
            InputManager inputManager = GetComponent<InputManager>();
            inputManager.playerMovement = level.GetComponentInChildren<PlayerMovement>();

        }

    }
}

