using System;

namespace GameJam2015MonoGame.Actors.Player
{
    public class FacingChangedEventArgs : EventArgs
    {
        public FacingChangedEventArgs(Facing facing)
        {
            this.NewFacing = facing;
        }

        public Facing NewFacing { get; set; }
    }
}
