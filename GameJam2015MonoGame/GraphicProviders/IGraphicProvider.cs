namespace GameJam2015MonoGame.GraphicProviders
{
    public interface IGraphicProvider
    {
        /// <summary>
        /// Gets the width of the graphic.
        /// </summary>
        /// <value>
        /// The width of the graphic.
        /// </value>
        float GraphicWidth { get; }

        /// <summary>
        /// Gets the height of the graphic.
        /// </summary>
        /// <value>
        /// The height of the graphic.
        /// </value>
        float GraphicHeight { get; }

        void LoadContent(IContentLoader loader);

        void Draw(float xPosition, float yPosition, IGraphicDrawer drawer);
    }
}