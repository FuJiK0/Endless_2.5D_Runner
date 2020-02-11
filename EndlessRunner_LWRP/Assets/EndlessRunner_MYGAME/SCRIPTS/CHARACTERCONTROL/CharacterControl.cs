﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public enum TranistionParemeters
    {
        Run,
        Jump,
        ForceTransition,
        Grounded,
        Dash,
        OnSlope,
        Die,
        DoubleJump,
    }
    public class CharacterControl : MonoBehaviour
    {
        [Header("INPUTS")]
        public bool Jump;
        public bool Dash;
        public bool startRunning;

        [Header("DETECTORS")]
        public bool isGrounded;
        public bool isOnSlope;
        public bool Death;

        [Header("Floats")]
        public float FallMultiplier;
        [SerializeField]
        public float lowJumpGravity;
        [SerializeField]
        public float slopeFroce;

        [Header("UpdateBoxCollider")]
        public Vector3 targetCenter_C;
        public float CenterUpdate_Speed_C;
        public float targetHeight;
        public bool UpdateNow;

        [Header("SUB-COMPONENTS")]
        public Animator anim;
        public CapsuleCollider Ccollider;
        private Rigidbody rb;
        public Rigidbody RIGIDBODY
        {
            get
            {
                if (rb == null)
                {
                    rb = GetComponent<Rigidbody>();
                }
                return rb;
            }
        }
        void Awake()
        {
            startRunning = false;
            anim = GetComponentInChildren<Animator>();
            Ccollider = GetComponent<CapsuleCollider>();
        }
        public void CacheCharacterControl(Animator animator)
        {
            PlayerStateBase[] arr = animator.GetBehaviours<PlayerStateBase>();

            foreach (PlayerStateBase c in arr)
            {
                c.characterControl = this;
            }
        }
        void Update()
        {
            Time.timeScale = 0.3f;
            ApplyGravity();
        }
        void FixedUpdate()
        {
            UpdateCenter();
            UpdateSize();
        }
        void ApplyGravity()
        {
            //if character is falling increase acceraltion
            if (RIGIDBODY.velocity.y < 0f)
            {
                RIGIDBODY.velocity += Vector3.up * Physics.gravity.y * (FallMultiplier - 1) * Time.deltaTime;
            }
            //if it's  in air make him fall don't keep going up
            else if (RIGIDBODY.velocity.y > 0f && Jump == false)
            {
                RIGIDBODY.velocity += Vector3.up * Physics.gravity.y * (lowJumpGravity - 1) * Time.deltaTime;
            }
            //fixing that bouncing effect On Slope
            if (isOnSlope)
            {
                RIGIDBODY.AddForce(Vector3.down * slopeFroce);
            }
        }
        #region //update boxcollider functions
        void UpdateCenter()
        {
            if (!UpdateNow)
            {
                return;
            }
            if (Vector3.SqrMagnitude(Ccollider.center - targetCenter_C) > 0.01f)
            {
                Ccollider.center = Vector3.Lerp(Ccollider.center, targetCenter_C,
                    Time.fixedDeltaTime * CenterUpdate_Speed_C);
            }
        }
        void UpdateSize()
        {
            if (!UpdateNow)
            {
                return;
            }
            else
            {
                Ccollider.height = targetHeight;
            }
        }
        #endregion
        protected void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Obsticel"))
            {
                Death = true;
            }
        }
        protected void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Slope"))
            {
                isGrounded = true;
            }
            if (collision.gameObject.CompareTag("Slope"))
            {
                isOnSlope = true;
            }
        }

        protected void OnCollisionExit(Collision collision)
        {
            Death = false;
            isGrounded = false;
            isOnSlope = false;
        }
    }
}