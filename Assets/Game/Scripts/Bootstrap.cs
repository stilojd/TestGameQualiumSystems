using Assets.Game.Scripts.Game;
using Assets.Game.Scripts.Game.Timer.TimerCore;
using Assets.Game.Scripts.Game.Timer.TimerView;
using Assets.Game.Scripts.Panels;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Scripts
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Text text;
        [SerializeField] private GameMenuManager gameMenuManager;
        [SerializeField] private GameObject gameOverColider;
        [SerializeField] private Joystick joystick;

        private ITimer myTimer;
        private GameSattings gameSattings;

        void Start()
        {
            gameSattings = new GameSattings();

            ITimerView timerView = new TimerView1(text);
            myTimer = new MyTimer(timerView);

            var newGameObject = new GameObject("Game");
            Game_KeepBounce game_KeepBounce = newGameObject.AddComponent<Game_KeepBounce>();
            game_KeepBounce.Initialize(gameMenuManager, myTimer, gameOverColider, joystick, gameSattings);
            game_KeepBounce.LoadPrefabs();
            IGame game = game_KeepBounce;

            gameMenuManager.PanelsInitialization(game, gameSattings);
            gameMenuManager.OpenPanel(GameMenu.StartMenu);
        }

        void Update()
        {
            myTimer.UpdateTimer();
        }
    }
}