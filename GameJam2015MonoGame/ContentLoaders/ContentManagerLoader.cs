using System;
using Microsoft.Xna.Framework.Content;

namespace GameJam2015MonoGame.ContentLoaders
{
    internal class ContentManagerLoader : IContentLoader
    {
        private readonly ContentManager _contentManager;

        internal ContentManagerLoader(ContentManager contentManager)
        {
            if (contentManager == null)
            {
                throw new ArgumentNullException(nameof(contentManager));
            }

            this._contentManager = contentManager;
        }

        public T LoadContent<T>(string assetPath)
        {
            return this._contentManager.Load<T>(assetPath);
        }
    }
}
