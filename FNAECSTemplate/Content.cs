using System;
using System.IO;
using System.Reflection;
using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace FNAECSTemplate.Content;
public static class Textures
{
    public static void Initialize(ContentManager content)
    {
    }
}
public static class Fonts
{
    public static FontSystem Opensans { get; private set; }
    public static void Initialize(ContentManager content)
    {
        Opensans = new FontSystem();
        Opensans.AddFont(File.ReadAllBytes(
            Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), content.RootDirectory, @"Fonts/opensans.ttf"
            )
        ));
    }
}
public static class SFX
{
    public static void Initialize(ContentManager content)
    {
    }
}
public static class Songs
{
    public static void Initialize(ContentManager content)
    {
    }
}

public static class AllContent
{
    public static void Initialize(ContentManager content)
    {
        Textures.Initialize(content);
        Fonts.Initialize(content);
        SFX.Initialize(content);
        Songs.Initialize(content);
    }
}
