using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam2015MonoGame
{
    internal class BlockPositionRandomizer : IRandomNumberProvider
    {
        public float GetRandomNumber()
        {
            var rand = new Random();
            return rand.Next(300, 600);
        }
    }
}
