using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MoonTools.ECS;
using FNAECSTemplate.Systems;
using FNAECSTemplate.Components;
using FNAECSTemplate.Renderers;


namespace FNAECSTemplate
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager GraphicsDeviceManager { get; }
        private ContentManager ContentManager { get; }

        private static World World { get; } = new World();
        private static ExampleSystem? ExampleSystem;
        private static ExampleRenderer? ExampleRenderer;

        SpriteBatch SpriteBatch;
        SpriteFont ExampleFont;

        [STAThread]
        internal static void Main()
        {
            using (Game1 game = new Game1())
            {
                game.Run();
            }
        }
        private Game1()
        {
            GraphicsDeviceManager = new GraphicsDeviceManager(this);

            GraphicsDeviceManager.PreferredBackBufferWidth = 1024;
            GraphicsDeviceManager.PreferredBackBufferHeight = 768;
            GraphicsDeviceManager.SynchronizeWithVerticalRetrace = true;

            IsFixedTimeStep = false;
            IsMouseVisible = true;

        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDeviceManager.GraphicsDevice);

            /*
            SYSTEMS
            */
            ExampleSystem = new ExampleSystem(World);

            /*
            RENDERERS
            */
            ExampleRenderer = new ExampleRenderer(World, SpriteBatch);

            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            ExampleSystem.Update(gameTime.ElapsedGameTime);
            World.FinishUpdate();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
        }
    }
}