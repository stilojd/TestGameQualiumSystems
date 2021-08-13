using System;
using Assets.Game.Scripts.Game.Timer.TimerCore;
using Assets.Game.Scripts.Panels;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Game.Scripts.Game
{
    public class Game_KeepBounce : MonoBehaviour, IGame
    {
        private ITimer myTimer;
        private GameMenuManager gameMenuManager;
        private GameSattings shapeOfPlatform;
        private Joystick joystick;
        private GameObject platformGameObject;
        private GameObject playerGameObject;
        PlatformContfoller platformContfoller;

        public void Initialize(GameMenuManager gameMenuManager, ITimer myTimer, GameObject gameOverTrigger, Joystick joystick, GameSattings shapeOfPlatform)
        {
            this.gameMenuManager = gameMenuManager;
            this.myTimer = myTimer;
            this.joystick = joystick;
            this.shapeOfPlatform = shapeOfPlatform;

            GameOverTrigger gameOverScript = gameOverTrigger.AddComponent<GameOverTrigger>();
            gameOverScript.Initialize(this);
        }

        public void LoadPrefabs()
        {
            DeletePrefaps();

            var platformPrefab = Resources.Load<GameObject>(shapeOfPlatform.name);
            platformGameObject = Instantiate(platformPrefab);

            var playerPrefab = Resources.Load<GameObject>("Player");
            playerGameObject = Instantiate(playerPrefab);

            platformContfoller = platformGameObject.AddComponent<PlatformContfoller>();
            platformContfoller.Inicialization(joystick);
            platformContfoller.gameObject.GetComponent<PlatformContfoller>().enabled = false;
        }

        private void DeletePrefaps()
        {
            if (platformGameObject)
            {
                Destroy(platformGameObject);
            }
            if (playerGameObject)
            {
                Destroy(playerGameObject);
            }
        }

        public void StartGame()
        {
            myTimer.Restart();
            gameMenuManager.ClosePanel(GameMenu.StartMenu);
            myTimer.Start();
            platformContfoller.gameObject.GetComponent<PlatformContfoller>().enabled = true;
        }

        //public void Pause() TODO
        //{

        //}

        public void Reset()
        {
            Destroy(platformGameObject);
            myTimer.Restart();
            LoadPrefabs();
            gameMenuManager.ClosePanel(GameMenu.GameOverMenu);
            myTimer.Start();
            platformContfoller.gameObject.GetComponent<PlatformContfoller>().enabled = true;
        }

        public void GameOver()
        {
            Destroy(playerGameObject, 2f);
            gameMenuManager.OpenPanel(GameMenu.GameOverMenu);
            myTimer.Pause();
        }
        public void SettingsApply()
        {
            LoadPrefabs();
        }
    }
}