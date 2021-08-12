using UnityEngine;

namespace Assets.Game.Scripts.Game.Timer.TimerView
{
    public interface ITimerView
    {
        void UpdateView(int minutes, int seconds, int miliseconds);
    }
}