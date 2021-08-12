using UnityEngine;

namespace Assets.Game.Scripts.Game
{
    public class GameOverTrigger : MonoBehaviour
    {
        private IGame game;

        public void Initialize(IGame game)
        {
            this.game = game;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                game.GameOver();
            }
        }
    }
}
