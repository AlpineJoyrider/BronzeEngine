using BronzeEngine.Utils;
using OpenTK.Graphics.OpenGL4;

namespace BronzeEngine.Core;

public static class BEngine
{
    private static readonly BRenderWindow Window = new();

    public static void Setup()
    {
        BLogger.Log("Engine setup complete.");
    }

    public static void Run()
    {
        Window.Run();
    }

    public static void Shutdown()
    {
        BLogger.Log("Engine shutdown.");
    }
}