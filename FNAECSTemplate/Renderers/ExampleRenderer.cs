using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MoonTools.ECS;
using FNAECSTemplate.Components;



namespace FNAECSTemplate.Renderers
{
    public class ExampleRenderer : MoonTools.ECS.Renderer
    {
        private Filter ExampleFilter { get; }
        private SpriteBatch SpriteBatch { get; }
        private SpriteFont SpriteFont { get; }

        public ExampleRenderer(World world, SpriteBatch spriteBatch, SpriteFont font) : base(world)
        {
            SpriteBatch = spriteBatch;
            SpriteFont = font;
            ExampleFilter = FilterBuilder
                .Include<ExampleComponent>()
                .Build();
        }

        public void Draw()
        {
            SpriteBatch.Begin();
            float y = 0;
            foreach (var example in ExampleFilter.Entities)
            {
                var component = Get<ExampleComponent>(example);

                SpriteBatch.DrawString(
                    SpriteFont,
                    String.Format("{0}: {1}", example.ID, component.ExampleProperty),
                    new Vector2(0, y),
                    new Color(component.ExampleProperty, component.ExampleProperty, component.ExampleProperty)
                );
                y += 70;
            }
            SpriteBatch.End();
        }
    }
}