using BronzeEngine.Utils;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace BronzeEngine.Core;

public class BRenderWindow : GameWindow
{
    public int Fps { get; private set; }
    
    #region Constructors
    
    public BRenderWindow() : base(GameWindowSettings.Default,
        new NativeWindowSettings
            { ClientSize = new Vector2i(1024, 768), Title = "Bronze Engine", StartVisible = false })
    {
        CenterWindow();
        IsVisible = true;
        BLogger.Log("Render window created with OpenGL context.");
        BLogger.Log($"OpenGL version: {GL.GetString(StringName.Version)}");
        BLogger.Log($"OpenGL vendor: {GL.GetString(StringName.Vendor)}");
    }
    
    public BRenderWindow(string title, int width, int height) : base(GameWindowSettings.Default,
        new NativeWindowSettings
            { ClientSize = new Vector2i(width, height), Title = title, StartVisible = false })
    {
        CenterWindow();
        IsVisible = true;
        BLogger.Log("Render window created with OpenGL context.");
        BLogger.Log($"OpenGL version: {GL.GetString(StringName.Version)}");
        BLogger.Log($"OpenGL vendor: {GL.GetString(StringName.Vendor)}");
    }
    
    #endregion

    #region Ovverides

    protected override void OnLoad()
    {
        GL.Enable(EnableCap.DepthTest);
        GL.ClearColor(Color4.Black);
        
        base.OnLoad();
    }

    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        Fps = (int)(1.0 / args.Time);

        Title = $"Bronze Engine - Fps: {Fps}";
        
        base.OnUpdateFrame(args);
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        
        SwapBuffers();
        
        base.OnRenderFrame(args);
    }

    protected override void OnResize(ResizeEventArgs e)
    {
        base.OnResize(e);
    }

    protected override void OnUnload()
    {
        BLogger.Log("Render window closed down.");
        BLogger.Log("OpenGL context closed.");
        
        base.OnUnload();
    }

    protected override void OnKeyDown(KeyboardKeyEventArgs e)
    {
        if (IsKeyPressed(Keys.Escape))
            Close();
        
        base.OnKeyDown(e);
    }

    protected override void OnMouseMove(MouseMoveEventArgs e)
    {
        base.OnMouseMove(e);
    }

    #endregion
}