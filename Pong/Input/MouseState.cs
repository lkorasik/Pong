﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Input
{
    class MouseState
    {
        private static readonly MouseState Instance = new MouseState();
        public static MouseState GetInstance => Instance;

        private bool IsLeft;

        /// <summary>
        /// Create instance of this class
        /// </summary>
        private MouseState()
        {
            IsLeft = false;
        }
    }
}
