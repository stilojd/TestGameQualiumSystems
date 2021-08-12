using Assets.Game.Scripts.Game;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Scripts.Panels
{
    public class SettingsPanelBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject plateButtonGameObject;
        [SerializeField] private GameObject platformButtonGameObject;

        private IGame game;
        private GameMenuManager gameMenuManager;

        public void Initialize(IGame game, GameSattings shapeOfPlatform, GameMenuManager gameMenuManager)
        {
            this.game = game;
            this.gameMenuManager = gameMenuManager;
            AddMethodsToButtons(shapeOfPlatform, gameMenuManager);
        }

        private void AddMethodsToButtons(GameSattings shapeOfPlatform, GameMenuManager gameMenuManager)
        {
            plateButtonGameObject.GetComponent<Button>().onClick.AddListener(() => shapeOfPlatform.SetPlatfomPrefabName(plateButtonGameObject.name));
            plateButtonGameObject.GetComponent<Button>().onClick.AddListener(() => gameMenuManager.ClosePanel(GameMenu.SettingsMenu));
            platformButtonGameObject.GetComponent<Button>().onClick.AddListener(() => shapeOfPlatform.SetPlatfomPrefabName(platformButtonGameObject.name));
            platformButtonGameObject.GetComponent<Button>().onClick.AddListener(() => gameMenuManager.ClosePanel(GameMenu.SettingsMenu));
        }

        public void ClosePanel()
        {
            gameObject.SetActive(false);
            gameMenuManager.OpenPanel(GameMenu.StartMenu);
            game.SettingsApply();
        }

        public void OpenPanel()
        {
            gameObject.SetActive(true);
            gameMenuManager.ClosePanel(GameMenu.StartMenu);
        }
    }
}