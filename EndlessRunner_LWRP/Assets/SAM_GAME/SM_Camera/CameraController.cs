﻿using UnityEngine;

namespace RunnerGame
{
    public enum CameraTrigger
    {
        Default,
        Shake,
    }
    public class CameraController : MonoBehaviour
    {
        private Animator animator;     
        public Animator ANIMATOR
        {
            get
            {
                if (animator == null)
                {
                    animator = GetComponent<Animator>();
                }
                return animator;
            }
        }

        public void TriggerCamera(CameraTrigger trigger)
        {
            ANIMATOR.SetTrigger(trigger.ToString());
        }
    }
}
