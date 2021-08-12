using Assets.Game.Scripts.Game;
using UnityEngine;

namespace Assets.Game.Scripts.Panels
{
    public class GameMenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject startPanelGameObject;
        [SerializeField] private GameObject gameOverPanelGameObject;
        [SerializeField] private GameObject settingsPanelGameObject;

        private StartPanelBehaviour startPanelBehaviour;
        private GameOverPanelBehaviour gameOverPanelBehaviour;
        private SettingsPanelBehaviour settingsPanelBehaviour;

        public void Start()
        {
            startPanelBehaviour = startPanelGameObject.GetComponent<StartPanelBehaviour>();
            gameOverPanelBehaviour = gameOverPanelGameObject.GetComponent<GameOverPanelBehaviour>();
            settingsPanelBehaviour = settingsPanelGameObject.GetComponent<SettingsPanelBehaviour>();
        }

        public void PanelsInitialization(IGame game, GameSattings shapeOfPlatform)
        {
            startPanelBehaviour.Initialize(game, this);
            gameOverPanelBehaviour.Initialize(game, this);
            settingsPanelBehaviour.Initialize(game, shapeOfPlatform, this);
        }

        public void OpenPanel(GameMenu gameMenu)
        {
            switch (gameMenu)
            {
                case GameMenu.StartMenu:
                    startPanelBehaviour.OpenPanel();
                    break;

                case GameMenu.GameOverMenu:
                    gameOverPanelBehaviour.OpenPane();
                    break;

                case GameMenu.SettingsMenu:
                    settingsPanelBehaviour.OpenPanel();
                    break;
            }
        }

        public void ClosePanel(GameMenu gameMenu)
        {
            switch (gameMenu)
            {
                case GameMenu.StartMenu:
                    startPanelBehaviour.ClosePanel();
                    break;

                case GameMenu.GameOverMenu:
                    gameOverPanelBehaviour.ClosePane();
                    break;

                case GameMenu.SettingsMenu:
                    settingsPanelBehaviour.ClosePanel();
                    break;
            }
        }
    }
}