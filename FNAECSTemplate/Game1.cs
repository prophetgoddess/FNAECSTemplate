using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MoonTools.ECS;
using FNAECSTemplate.Systems;
using FNAECSTemplate.Components;
using FNAECSTemplate.Renderers;
using FontStashSharp;
using FNAECSTemplate.Content;

namespace FNAECSTemplate;

public class Game1 : Game
{
    GraphicsDeviceManager GraphicsDeviceManager { get; }

    /*
    the World is the place where all our entities go.
    */
    World World { get; } = new World();

    Input Input;
    ExampleSystem ExampleSystem;
    ExampleRenderer ExampleRenderer;

    SpriteBatch SpriteBatch;

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
        //setup our graphics device, default window size, etc
        //here is where i will make a plea to you, intrepid game developer:
        //please default your game to windowed mode.
        GraphicsDeviceManager = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";

        GraphicsDeviceManager.PreferredBackBufferWidth = 1024;
        GraphicsDeviceManager.PreferredBackBufferHeight = 768;
        GraphicsDeviceManager.SynchronizeWithVerticalRetrace = true;

        IsFixedTimeStep = false;
        IsMouseVisible = true;
    }

    //you'll want to do most setup in LoadContent() rather than your constructor.
    protected override void LoadContent()
    {
        /*
        CONTENT
        */

        /*
        SpriteBatch is FNA/XNA's abstraction for drawing sprites on the screen.
        you want to do is send all the sprites to the GPU at once, 
        it's much more efficient to send one huge batch than to send sprites piecemeal. 
        See more in the Renderers/ExampleRenderer.cs. 
        */
        SpriteBatch = new(GraphicsDevice);

        AllContent.Initialize(Content);
        /*
        SYSTEMS
        */

        /*
        here we set up all our systems. 
        you can pass in information that these systems might need to their constructors.
        it doesn't matter what order you create the systems in, we'll specify in what order they run later.
        */
        ExampleSystem = new(World);
        Input = new(World);

        /*
        RENDERERS
        */

        //same as above, but for the renderer
        ExampleRenderer = new(World, SpriteBatch);

        /*
        ENTITIES
        */

        for (int i = 0; i < 10; i++)
        {
            var e = World.CreateEntity();
            World.Set(e, new ExampleComponent(0f));
        }

        base.LoadContent();
    }

    //sometimes content needs to be unloaded, but it usually doesn't.
    protected override void UnloadContent()
    {
        base.UnloadContent();
    }


    protected override void Update(GameTime gameTime)
    {
        /*
        here we call all our system update functions. 
        call them in the order you want them to run. 
        other ECS libraries have a master "update" function that does this for you,
        but moontools.ecs does not. this lets you have more control
        over the order systems run in, and whether they run at all.
        */
        Input.Update(gameTime.ElapsedGameTime); //always update this before anything that takes inputs
        ExampleSystem.Update(gameTime.ElapsedGameTime);
        World.FinishUpdate(); //always call this at the end of your update function.
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue); //set the color of the background. cornflower blue is XNA tradition.

        /*
        call renderers here.
        renderers don't get passed the game time. 
        if you are thinking about passing the game time to a renderer
        in order to do something, try doing it some other way. you'll thank me later.
        */
        ExampleRenderer.Draw();
        base.Draw(gameTime);
    }
}