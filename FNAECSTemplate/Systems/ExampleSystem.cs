using System;
using MoonTools.ECS;
using FNAECSTemplate.Components;

namespace FNAECSTemplate.Systems
{
    public class ExampleSystem : MoonTools.ECS.System
    {
        private Filter ExampleFilter { get; }
        private Random rnd { get; } = new Random();

        public ExampleSystem(World world) : base(world)
        {
            ExampleFilter = FilterBuilder
                            .Include<ExampleComponent>()
                            .Build();
        }

        public override void Update(TimeSpan delta)
        {
            foreach (var example in ExampleFilter.Entities)
            {
                Set(example, new ExampleComponent(rnd.NextSingle()));
            }
        }
    }
}