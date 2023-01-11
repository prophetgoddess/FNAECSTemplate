using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MoonTools.ECS;
using FNAECSTemplate.Systems;
using FNAECSTemplate.Components;
using FNAECSTemplate.Renderers;
using SpriteFontPlus;

namespace FNAECSTemplate
{
    public class Game1 : Game
    {
        GraphicsDeviceManager GraphicsDeviceManager { get; }

        static World World { get; } = new World();
        static ExampleSystem? ExampleSystem;
        static ExampleRenderer? ExampleRenderer;

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
            Content.RootDirectory = "Content";

            GraphicsDeviceManager.PreferredBackBufferWidth = 1024;
            GraphicsDeviceManager.PreferredBackBufferHeight = 768;
            GraphicsDeviceManager.SynchronizeWithVerticalRetrace = true;

            IsFixedTimeStep = false;
            IsMouseVisible = true;

        }

        protected override void LoadContent()
        {
            /*
            CONTENT
            */

            SpriteBatch = new SpriteBatch(GraphicsDevice);

            ExampleFont = TtfFontBaker.Bake(
                File.ReadAllBytes(
                    Path.Combine(
                        Content.RootDirectory, "opensans.ttf"
                    )
                ),
                64,
                1024,
                1024,
                new[]
                {
                    CharacterRange.BasicLatin,
                    CharacterRange.LatinExtendedA,
                    CharacterRange.LatinExtendedB,
                    CharacterRange.Latin1Supplement
                }
            ).CreateSpriteFont(GraphicsDevice);

            /*
            SYSTEMS
            */
            ExampleSystem = new ExampleSystem(World);

            /*
            RENDERERS
            */
            ExampleRenderer = new ExampleRenderer(World, SpriteBatch, ExampleFont);

            /*
            ENTITIES
            */

            for (int i = 0; i < 10; i++)
            {
                var e = World.CreateEntity();
                World.Set<ExampleComponent>(e, new ExampleComponent(0f));
            }

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
            ExampleRenderer.Draw();
            base.Draw(gameTime);
        }
    }
}