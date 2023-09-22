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
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    namespace Content;
    ";

    static string TexturesHeader =
    @"public static class Textures
    {
    ";

    static string TexturesInitializer =
    @"public static void Initialize(GraphicsDevice graphicsDevice, string contentDirectory)
    {
    ";

    static string LoadTexture =
    @"using (FileStream fs = File.OpenRead(Path.Join(contentDirectory, ""{0}.png"")))
        {1} = Texture2D.FromStream(graphicsDevice, fs);
    ";

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
            File.Create(targetFile);
        }

        var textureAtlases = Directory.GetFiles(sourceFolder, "*.json", SearchOption.AllDirectories);

        var fileContents = new StringBuilder();
        fileContents.Append(Header);
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

        fileContents.Append(TexturesInitializer);

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

        fileContents.Append("}");
        fileContents.Append("}");

        File.WriteAllText(targetFile, fileContents.ToString());
    }

}