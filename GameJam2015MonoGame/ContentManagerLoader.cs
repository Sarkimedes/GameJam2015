using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace GameJam2015MonoGame
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
