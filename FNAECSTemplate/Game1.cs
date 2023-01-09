using System;

using Microsoft.Xna.Framework;

namespace FNAECSTemplate
{
    public class Game1 : Game
    {
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
            GraphicsDeviceManager gdm = new GraphicsDeviceManager(this);

            gdm.PreferredBackBufferWidth = 1024;
            gdm.PreferredBackBufferHeight = 768;
            gdm.SynchronizeWithVerticalRetrace = true;

            IsFixedTimeStep = false;
            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}