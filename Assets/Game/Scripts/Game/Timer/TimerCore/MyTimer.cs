using Assets.Game.Scripts.Game.Timer.TimerView;
using UnityEngine;

namespace Assets.Game.Scripts.Game.Timer.TimerCore
{
    public class MyTimer : ITimer
    {
        public ITimerView timerView;

        private bool isRun = false;
        private int minute;
        private int second;
        private int miliseconds;
        private float currentTime = 0f;

        public MyTimer(ITimerView timerView)
        {
            this.timerView = timerView;
        }

        public void Start()
        {
            isRun = true;
        }

        public void UpdateTimer()
        {
            if (isRun)
            {
                GetTimerTime();
                timerView.UpdateView(minute, second, miliseconds);
            }
        }

        public void Pause()
        {
            isRun = false;
        }

        public void Restart()
        {
            currentTime = 0;
            GetTimerTime();
            timerView.UpdateView(minute, second, miliseconds);
        }

        private void GetTimerTime()
        {
            currentTime += Time.deltaTime;
            miliseconds = (int)(currentTime * 100 % 100);
            second = Mathf.RoundToInt(currentTime);

            if (second == 60)
            {
                minute += 1;
                second = 0;
                currentTime = 0;
            }
        }
    }
}