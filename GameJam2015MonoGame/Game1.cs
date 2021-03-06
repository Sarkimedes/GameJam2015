﻿using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using GameJam2015MonoGame.Actors.Block;
using GameJam2015MonoGame.Actors.Player;
using GameJam2015MonoGame.ContentLoaders;
using GameJam2015MonoGame.GraphicDrawers;
using GameJam2015MonoGame.GraphicProviders;
using GameJam2015MonoGame.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameJam2015MonoGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        /// <summary>
        /// The number of blocks on screen
        /// </summary>
        private static readonly int NumberOfBlocks = 10;

        private HankGraphicProvider _hankGraphicProvider;
        private KeyboardInputHandler _inputHandler;

        private Player _player;

        private List<FallingBlock> _blocks; 

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this._blocks = new List<FallingBlock>();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            for (int i = 0; i < NumberOfBlocks; ++i)
            {
                //Add blocks in here
                var block = new FallingBlock(
                    new BlockGraphicProvider(), 
                    new BlockPositionRandomizer(),
                    new ViewportBlockLimiter(this.GraphicsDevice.Viewport));
                this._blocks.Add(block);
            }

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            this._hankGraphicProvider = new HankGraphicProvider();
            this._inputHandler = new KeyboardInputHandler();
            this._player = new Player(this._inputHandler, this._hankGraphicProvider);
            ContentManagerLoader loader = new ContentManagerLoader(this.Content);
            this._player.LoadContent(loader);
            this._player.YPosition = this.GraphicsDevice.Viewport.Height - (this._player.Height * 4);
            this._player.XPosition = this.GraphicsDevice.Viewport.Width/2;
            this._player.FacingChanged += (sender, e) => this._hankGraphicProvider.HandlePlayerFacingChange(sender, e);
            foreach (var block in _blocks)
            {
                block.LoadContent(loader);
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            this._player.Update();
            foreach (var item in this._blocks)
            {
                if (CollisionOccurred(this._player, item))
                {
                     this._player.IsDead = true;
                }
                item.Update();
            }

            base.Update(gameTime);
        }

        private bool CollisionOccurred(Player player, FallingBlock block)
        {
            Rectangle playerRectangle = new Rectangle((int)player.XPosition, (int)player.YPosition, (int)player.Width, (int)player.Height);
            Rectangle enemyRectangle = new Rectangle((int)block.XPosition, (int)block.YPosition, (int)block.Width, (int)block.Height);
            return playerRectangle.Intersects(enemyRectangle);
        }

        void ProcessCollisions()
        {
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            this._spriteBatch.Begin();
            var drawer = new SpriteBatchGraphicDrawer(this._spriteBatch);
            foreach (var block in _blocks)
            {
                block.Draw(drawer);
            }
            
            this._player.Draw(drawer);
            this._spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
