using System;
using MoonTools.ECS;
using FNAECSTemplate.Components;
using FNAECSTemplate.Messages;


namespace FNAECSTemplate.Systems;

/*
this is a system. systems can read and modify components and entities. 
*/
public class ExampleSystem : MoonTools.ECS.System
{
    private Filter ExampleFilter { get; }
    private System.Random rnd { get; } = new System.Random();

    public ExampleSystem(World world) : base(world)
    {
        /*
        this is a filter. a filter allows us to specify which entities we do and don't want.
        a filter will, every frame, get us every single entity that matches its criteria.
        */
        ExampleFilter = FilterBuilder
                        .Include<ExampleComponent>()
                        .Build();
    }

    public override void Update(TimeSpan delta)
    {
        //we get the entities that the filter has found this frame from ExampleFilter.Entities.
        //the filter is programmed in such a way that it can very efficiently query every single
        //entity in the game and retrieve only the ones we want, even if there are thousands of entities.
        foreach (var example in ExampleFilter.Entities)
        {
            /*
            then, we use Set to set the component on the entity.
            if the property ExampleProperty on ExampleComponent weren't readonly
            and we just changed it to some other value, it wouldn't actually change the value
            in the component store. we have to call Set() to update the component store so that
            other systems can read our changes and they'll persist across frames.
            */
            foreach (var input in ReadMessages<InputAction>())
                Set(example, new ExampleComponent(rnd.NextSingle()));
        }
    }
}