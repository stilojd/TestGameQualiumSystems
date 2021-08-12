using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Game
{
    public interface IGame
    {
        void StartGame();
        //void Pause(); TODO
        void Reset();
        void GameOver();
        void SettingsApply();
    }
}