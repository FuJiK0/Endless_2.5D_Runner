﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class CharacterControl : MonoBehaviour
    {
        //inputs
        public bool Jump;
        public bool DoubleJump;
        public bool Dowalljump = false;
        public bool CanwallJump;
        public bool CanDoubleJump;
        public bool DoDash;

        public bool faceRight;

        public bool IsGrounded;
        public bool move;

        Vector3 moveForward;

        public float speed;
        public Rigidbody rb;

        private void Start()
        {
            Application.targetFrameRate = 60;
            rb = GetComponent<Rigidbody>();
        }
        void Update()
        {
            if (IsGrounded)
            {
                move = true;
            }
            else
            {
                move = false;
            }
        }
        void FixedUpdate()
        {
            if (move)
            {
                this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                rb.velocity = new Vector3(0, rb.velocity.y, speed);
            }
        }
    }
}




