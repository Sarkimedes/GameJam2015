﻿using Microsoft.Xna.Framework.Input;

namespace GameJam2015MonoGame.Utility
{
    class KeyboardInputHandler : IInputHandler
    {
        public bool JumpPressed
        {
            get { return IsJumpDown(); }
            set { }
        }

        private bool IsJumpDown()
        {
            var keyboardState = Keyboard.GetState();
            return keyboardState.IsKeyDown(Keys.Space);
        }

        private bool IsLeftDown()
        {
            var keyboardState = Keyboard.GetState();
            return keyboardState.IsKeyDown(Keys.Left);
        }

        public bool LeftPressed { get { return IsLeftDown(); }
            set { }
        }
        public bool RightPressed { get { return IsRightDown(); } set {} }

        private bool IsRightDown()
        {
            var keyboardState = Keyboard.GetState();
            return keyboardState.IsKeyDown(Keys.Right);
        }
    }
}
