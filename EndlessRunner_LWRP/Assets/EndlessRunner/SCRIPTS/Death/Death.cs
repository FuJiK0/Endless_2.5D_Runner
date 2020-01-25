﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class Death : MonoBehaviour
    {
        protected CharacterControl Control;
        // Start is called before the first frame update
        void Start()
        {
            Control = GetComponent<CharacterControl>();
        }
        // Update is called once per frame
        void Update()
        {
            if (Control.Death)
            {
                Control.RIGIDBODY.velocity = Vector3.zero;
                Control.RIGIDBODY.velocity = new Vector3(0, 0, -13);
                Control.anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("DeathAnimator");
            }
        }
    }
}
