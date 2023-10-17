using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MoonTools.ECS;
using FNAECSTemplate.Components;
using FontStashSharp;
using FNAECSTemplate.Content;

namespace FNAECSTemplate.Renderers;

/*
this is a renderer. a renderer is just like a system, 
but it lacks the capability to call Set() and update components.
*never* update components from within a renderer.

how you structure your renderers is up to you. 
you may get value from splitting your renderers up into say,
a HUD renderer and a world renderer. or you can go monolith-style.
there are advantages to both ([lcd soundsystem voice] advantages! advantages!),
but the monolith-style renderer can be more useful in a 3D context.
*/
public class ExampleRenderer : Renderer
{
    private Filter ExampleFilter;
    private SpriteBatch SpriteBatch;

    public ExampleRenderer(World world, SpriteBatch spriteBatch) : base(world)
    {
        SpriteBatch = spriteBatch;
        ExampleFilter = FilterBuilder //for information about this, see Systems/ExampleSystem.cs
            .Include<ExampleComponent>()
            .Build();
    }

    /*
    note that unlike Update() in systems, Draw() is not an override. 
    this gives us the freedom to have multiple Draw() functions 
    and call them in whatever order we want.
    */
    public void Draw()
    {
        /*
        start the sprite batch. everything between SpriteBatch.Begin() and SpriteBatch.End() 
        is going to be in the same batch. everything that gets batched together has to use 
        the same shader, so if you have a special shader you want to put on certain objects only,
        they have to be in their own batch.

        it's also good practice to create a sprite atlas using a texture packer, 
        and draw all your sprites from the same Texture2D, specifying which sprite you want using
        the rectangle parameter. there are many tools out there that will spit out a packed texture
        and JSON metadata to get your rectangles from. i recommend cram: https://gitea.moonside.games/MoonsideGames/Cram
        */
        SpriteBatch.Begin();
        float y = 0;
        foreach (var example in ExampleFilter.Entities)
        {
            var component = Get<ExampleComponent>(example); //getting a component is much like setting a component

            /*
            here i'm using some magic numbers for things like the y coordinate and the font size.
            never do this in a real project. always store these in variables.
            practically, you'd probably be getting this information from a component.

            what this will do is put each of our components on a separate line of text, 
            and display the value of the example property while setting the font color
            to be white if the property is 1, black if it's 0, and various greys in between.
            */

            SpriteBatch.DrawString(
                Fonts.Opensans.GetFont(64),
                string.Format("{0}: {1}", example.ID, component.ExampleProperty),
                new Vector2(0, y),
                new Color(component.ExampleProperty, component.ExampleProperty, component.ExampleProperty)
            );
            y += 70;
        }
        SpriteBatch.End();
    }
}