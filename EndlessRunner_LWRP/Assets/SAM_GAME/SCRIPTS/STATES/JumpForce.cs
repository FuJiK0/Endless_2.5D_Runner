﻿using UnityEngine;

namespace RunnerGame
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/Ability/JumpForce")]
    public class JumpForce : ScriptableObjectData
    {
        [SerializeField]
        private float jumpForce;
        public override void OnEnter(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            float normal_JumpForce = 780;
            float Slope_JumpForce = 1000;

            if (!playerStateBase.characterControl.Slide)
            {
                jumpForce = normal_JumpForce;
            }
            else
            {
                jumpForce = Slope_JumpForce;
            }
            // playerStateBase.characterControl.RIGIDBODY.velocity = new Vector3
            //  (0f, JumpForce, forwardVel);
            playerStateBase.characterControl.RIGIDBODY.AddForce
                (playerStateBase.characterControl.transform.up * jumpForce);
        }
        public override void OnUpdate(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
        public override void OnExit(PlayerStateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            jumpForce = 0f;
        }
    }

}