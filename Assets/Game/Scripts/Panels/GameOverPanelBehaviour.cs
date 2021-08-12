using Assets.Game.Scripts.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Scripts.Panels
{
    public class GameOverPanelBehaviour : MonoBehaviour
    {
        [SerializeField] private Button resetButton;
        [SerializeField] private Button settingsButton;

        public void Initialize(IGame game, GameMenuManager gameMenuManager)
        {
            AddMethodsToButtons(game, gameMenuManager);
        }

        private void AddMethodsToButtons(IGame game, GameMenuManager gameMenuManager)
        {
            resetButton.onClick.AddListener(game.Reset);
            settingsButton.onClick.AddListener(() => { gameMenuManager.OpenPanel(GameMenu.SettingsMenu); gameMenuManager.ClosePanel(GameMenu.GameOverMenu); });
        }

        public void OpenPane()
        {
            gameObject.SetActive(true);
        }

        public void ClosePane()
        {
            gameObject.SetActive(false);
        }
    }
}