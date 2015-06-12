﻿using System.Collections.Generic;
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
            // TODO: Add your initialization logic here
            for (int i = 0; i < NumberOfBlocks; ++i)
            {
                //Add blocks in here
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
            this._hankGraphicProvider = new HankGraphicProvider(this._spriteBatch, Content);
            this._inputHandler = new KeyboardInputHandler();
            this._player = new Player(this._inputHandler, this._hankGraphicProvider);
            ContentManagerLoader loader = new ContentManagerLoader(this.Content);
            this._player.LoadContent(loader);
            this._player.YPosition = this.GraphicsDevice.Viewport.Height - (this._player.Height * 4);
            this._player.XPosition = this.GraphicsDevice.Viewport.Width/2;
            this._player.FacingChanged += (sender, e) =>
                this._hankGraphicProvider.HandlePlayerFacingChange(sender, e);
            // TODO: use this.Content to load your game content here
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
            // TODO: Add your update logic here
            this._player.Update();
            base.Update(gameTime);
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
            this._player.Draw(drawer);
            this._spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
