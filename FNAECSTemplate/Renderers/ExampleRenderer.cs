using MoonTools.ECS;
using FNAECSTemplate.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FNAECSTemplate.Renderers
{
    public class ExampleRenderer : MoonTools.ECS.Renderer
    {
        private Filter ExampleFilter { get; }
        private SpriteBatch SpriteBatch { get; }
        private SpriteFont SpriteFont { get; }

        public ExampleRenderer(World world, SpriteBatch spriteBatch) : base(world)
        {
            SpriteBatch = spriteBatch;
            ExampleFilter = FilterBuilder
                .Include<ExampleComponent>()
                .Build();
        }

        public void Draw()
        {
            SpriteBatch.Begin();
            foreach (var example in ExampleFilter.Entities)
            {
                var component = Get<ExampleComponent>(example);
            }
            SpriteBatch.End();
        }
    }
}