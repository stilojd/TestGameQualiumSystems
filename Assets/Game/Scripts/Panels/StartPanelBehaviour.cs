using Assets.Game.Scripts.Game;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Scripts.Panels
{
    public class StartPanelBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject StartButtonGameObject;
        [SerializeField] private GameObject SettingsButtonGameObject;

        public void Initialize(IGame game, GameMenuManager menuManager)
        {
            AddMethodsToButtons(game, menuManager);
        }

        private void AddMethodsToButtons(IGame game, GameMenuManager menuManager)
        {
            StartButtonGameObject.GetComponent<Button>().onClick.AddListener(game.StartGame);
            SettingsButtonGameObject.GetComponent<Button>().onClick.AddListener(() => menuManager.OpenPanel(GameMenu.SettingsMenu));
        }

        public void OpenPanel()
        {
            gameObject.SetActive(true);
        }

        public void ClosePanel()
        {
            gameObject.SetActive(false);
        }
    }
}