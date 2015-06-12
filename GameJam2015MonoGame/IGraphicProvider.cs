using Microsoft.Xna.Framework;

namespace GameJam2015MonoGame
{
    public interface IGraphicProvider
    {
        void LoadContent();

        void Draw(float xPosition, float yPosition);
    }
}