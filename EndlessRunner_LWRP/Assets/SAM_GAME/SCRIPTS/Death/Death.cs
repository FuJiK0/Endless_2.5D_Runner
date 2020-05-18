﻿using UnityEngine;

namespace RunnerGame
{
    public class Death : MonoBehaviour
    {
        protected CharacterControl Control;

        void Start()
        {
            Control = GetComponent<CharacterControl>();
        }
        void Update()
        {
            if (Control.Death)
            {
                StopAllCoroutines();
                CameraManger.Instance.ShakeCamera(0.4f);
                Control.anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("DeathAnimator");               
            }
        }
    }
}
