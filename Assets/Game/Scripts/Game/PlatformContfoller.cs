using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts
{
    public class PlatformContfoller : MonoBehaviour
    {
        private Joystick joystick;
        private bool isReady = false;

        public void Inicialization(Joystick joystick)
        {
            this.joystick = joystick;
            isReady = true;
        }

        void Update()
        {
            if (isReady)
                transform.rotation = Quaternion.Euler(joystick.Vertical * 30, 0, joystick.Horizontal * -30);
        }
    }
}