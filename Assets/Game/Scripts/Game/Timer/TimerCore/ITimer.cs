using System.Collections;
using System.Collections.Generic;

namespace Assets.Game.Scripts.Game.Timer.TimerCore
{
    public interface ITimer
    {
        void Start();
        void UpdateTimer();
        void Pause();
        void Restart();
    }
}