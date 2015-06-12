using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam2015MonoGame
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
