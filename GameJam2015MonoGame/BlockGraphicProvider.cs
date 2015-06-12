namespace GameJam2015MonoGame
{
    public class BlockGraphicProvider : IGraphicProvider
    {
        public BlockGraphicProvider()
        {
        }

        public float GraphicWidth { get; }
        public float GraphicHeight { get; }
        public void LoadContent()
        {
            throw new System.NotImplementedException();
        }

        public void Draw(float xPosition, float yPosition, IGraphicDrawer drawer)
        {
            drawer.Draw(xPosition, yPosition);
        }
    }
}