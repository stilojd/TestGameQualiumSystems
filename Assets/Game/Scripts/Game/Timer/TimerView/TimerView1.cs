using UnityEngine.UI;

namespace Assets.Game.Scripts.Game.Timer.TimerView
{
    public class TimerView1 : ITimerView
    {
        private Text text;

        public TimerView1(Text text)
        {
            this.text = text;
        }

        public void UpdateView(int minutes, int seconds, int miliseconds)
        {
            text.text = string.Format("{0:d2}:{1:d2}:{2:d2}", minutes, seconds, miliseconds);
        }
    }
}