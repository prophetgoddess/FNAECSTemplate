using System;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
namespace ContentImporter;

public struct ImageRect
{
    public string Name;
    public int X;
    public int Y;
    public int W;
    public int H;
    public int TrimOffsetX;
    public int TrimOffsetY;
    public int UntrimmedWidth;
    public int UntrimmedHeight;
}

public struct TextureAtlas
{
    public string Name;
    public int Width;
    public int Height;
    public ImageRect[] Images;
}

[JsonSerializable(typeof(TextureAtlas))]
internal partial class TextureAtlasContext : JsonSerializerContext
{
}

public class Program
{
    static JsonSerializerOptions SerializerOptions = new()
    {
        IncludeFields = true,
        WriteIndented = true
    };

    static TextureAtlasContext TextureAtlasContext = new(SerializerOptions);
    static TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

    static string Header =
    @"using System;
    using System.IO;
    using System.Reflection;
    using FontStashSharp;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Media;

    namespace Content;
    ";

    static string Initializer =
    @"public static void Initialize(ContentManager content)
    {
    ";

    static string TexturesHeader =
    @"public static class Textures
    {
    ";

    static string LoadTexture =
    @"{1} = content.Load<Texture2D>(""{0}"");
    ";

    static string FontsHeader =
    @"public static class Fonts
    {
    ";

    static string LoadFont =
    @"{1} = new FontSystem();
    {1}.AddFont(File.ReadAllBytes(
        Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), content.RootDirectory, @""{0}.ttf""
        )
    ));
    ";

    static string SFXHeader =
    @"public static class SFX
    {
    ";

    static string LoadSFX =
    @"{1} = content.Load<SoundEffect>(""{0}"");
    ";

    static string SongHeader =
    @"public static class Songs
    {
    ";

    static string LoadSong =
    @"{1} = content.Load<Song>(""{0}"");
    ";

    static void GetTextures(StringBuilder fileContents, string sourceFolder)
    {
        var textureAtlases = Directory.GetFiles(sourceFolder, "*.json", SearchOption.AllDirectories);

        fileContents.Append(TexturesHeader);

        foreach (var textureAtlas in textureAtlases)
        {
            var data = (TextureAtlas)JsonSerializer.Deserialize(
                File.ReadAllText(textureAtlas),
                typeof(TextureAtlas),
                TextureAtlasContext
            );

            fileContents.Append("public static Texture2D ");
            fileContents.Append(textInfo.ToTitleCase(Regex.Replace(data.Name, @"\s+", string.Empty)));
            fileContents.Append("{get; private set; }\n");

            foreach (var image in data.Images)
            {
                fileContents.Append("public static readonly Rectangle ");
                fileContents.Append(textInfo.ToTitleCase(Regex.Replace(Path.GetFileNameWithoutExtension(image.Name), @"\s+", string.Empty)));
                fileContents.Append(" = ");
                fileContents.Append(string.Format("new Rectangle({0}, {1}, {2}, {3});\n", image.X, image.Y, image.W, image.H));
            }
        }

        fileContents.Append(Initializer);

        foreach (var textureAtlas in textureAtlases)
        {
            var data = (TextureAtlas)JsonSerializer.Deserialize(
                File.ReadAllText(textureAtlas),
                typeof(TextureAtlas),
                TextureAtlasContext
            );

            fileContents.Append(string.Format(
                LoadTexture, data.Name, textInfo.ToTitleCase(Regex.Replace(data.Name, @"\s+", string.Empty))
            ));
        }

        fileContents.Append("}\n}\n");
    }

    static void GetFonts(StringBuilder fileContents, string sourceFolder)
    {
        var fonts = Directory.GetFiles(sourceFolder, "*.ttf", SearchOption.AllDirectories);

        fileContents.Append(FontsHeader);

        foreach (var font in fonts)
        {
            var name = textInfo.ToTitleCase(Regex.Replace(Path.GetFileNameWithoutExtension(font), @"\s+", string.Empty));
            fileContents.Append("public static FontSystem ");
            fileContents.Append(name);
            fileContents.Append("{get; private set; }\n");
        }

        fileContents.Append(Initializer);

        foreach (var font in fonts)
        {
            var name = textInfo.ToTitleCase(Regex.Replace(Path.GetFileNameWithoutExtension(font), @"\s+", string.Empty));
            fileContents.Append(string.Format(LoadFont, Path.GetFileNameWithoutExtension(font), name));
        }

        fileContents.Append("}\n}\n");
    }

    static void GetSFX(StringBuilder fileContents, string sourceFolder)
    {
        var sfx = Directory.GetFiles(sourceFolder, "*.wav", SearchOption.AllDirectories);

        fileContents.Append(SFXHeader);

        foreach (var s in sfx)
        {
            var name = textInfo.ToTitleCase(Regex.Replace(Path.GetFileNameWithoutExtension(s), @"\s+", string.Empty));
            fileContents.Append("public static SoundEffect ");
            fileContents.Append(name);
            fileContents.Append("{get; private set; }\n");
        }


        fileContents.Append(Initializer);

        foreach (var s in sfx)
        {
            var name = textInfo.ToTitleCase(Regex.Replace(Path.GetFileNameWithoutExtension(s), @"\s+", string.Empty));
            fileContents.Append(string.Format(LoadSFX, Path.GetFileName(s), name));
        }

        fileContents.Append("}\n}\n");
    }

    static void GetSongs(StringBuilder fileContents, string sourceFolder)
    {
        var songs = Directory.GetFiles(sourceFolder, "*.ogg", SearchOption.AllDirectories);

        fileContents.Append(SongHeader);

        foreach (var song in songs)
        {
            var name = textInfo.ToTitleCase(Regex.Replace(Path.GetFileNameWithoutExtension(song), @"\s+", string.Empty));
            fileContents.Append("public static Song ");
            fileContents.Append(name);
            fileContents.Append("{get; private set; }\n");
        }


        fileContents.Append(Initializer);

        foreach (var song in songs)
        {
            var name = textInfo.ToTitleCase(Regex.Replace(Path.GetFileNameWithoutExtension(song), @"\s+", string.Empty));
            fileContents.Append(string.Format(LoadSong, Path.GetFileName(song), name));
        }

        fileContents.Append("}\n}\n");
    }


    public static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: ContentImporter.exe <path_to_source_directory> <path_to_destination_file>");
            return;
        }

        var sourceFolder = args[0];
        var sourceAttributes = File.GetAttributes(sourceFolder);
        if ((sourceAttributes & FileAttributes.Directory) != FileAttributes.Directory)
        {
            Console.WriteLine("ERROR: source must be a directory");
            return;
        }

        var targetFile = args[1];
        if (File.Exists(targetFile))
        {
            var targetAttributes = File.GetAttributes(targetFile);
            if ((targetAttributes & FileAttributes.Directory) == FileAttributes.Directory)
            {
                Console.WriteLine("ERROR: target must be a file");
                return;
            }
        }
        else
        {
            using (File.Create(targetFile)) ;
        }


        var fileContents = new StringBuilder();
        fileContents.Append(Header);

        GetTextures(fileContents, sourceFolder);
        GetFonts(fileContents, sourceFolder);
        GetSFX(fileContents, sourceFolder);
        GetSongs(fileContents, sourceFolder);

        File.WriteAllText(targetFile, fileContents.ToString());
    }

}