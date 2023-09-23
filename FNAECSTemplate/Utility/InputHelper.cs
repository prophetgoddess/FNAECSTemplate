using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace FNAECSTemplate.Utility;

public enum GenericInputs
{
    //KEYS
    A,
    B,
    C,
    D,
    E,
    F,
    G,
    H,
    I,
    J,
    K,
    L,
    M,
    N,
    O,
    P,
    Q,
    R,
    S,
    T,
    U,
    V,
    W,
    X,
    Y,
    Z,
    D1,
    D2,
    D3,
    D4,
    D5,
    D6,
    D7,
    D8,
    D9,
    D0,
    Enter,
    Escape,
    Back,
    Tab,
    Space,
    OemMinus,
    OemCloseBrackets,
    OemOpenBrackets,
    OemBackslash,
    OemSemicolon,
    OemQuotes,
    OemTilde,
    OemComma,
    OemPeriod,
    BrowserForward,
    CapsLock,
    F1,
    F2,
    F3,
    F4,
    F5,
    F6,
    F7,
    F8,
    F9,
    F10,
    F11,
    F12,
    PrintScreen,
    Scroll,
    Pause,
    Insert,
    Home,
    PageUp,
    Delete,
    End,
    PageDown,
    Right,
    Left,
    Down,
    Up,
    NumLock,
    Divide,
    Multiply,
    OemPlus,
    NumPad1,
    NumPad2,
    NumPad3,
    NumPad4,
    NumPad5,
    NumPad6,
    NumPad7,
    NumPad8,
    NumPad9,
    NumPad0,
    LeftControl,
    LeftShift,
    LeftAlt,
    RightControl,
    RightShift,
    RightAlt
,

    //GAMEPAD BUTTONS
    AButton,
    BButton,
    XButton,
    YButton,
    BackButton,
    StartButton,
    LeftStick,
    RightStick,
    LeftShoulder,
    RightShoulder,
    DPadUp,
    DPadDown,
    DPadLeft,
    DPadRight,

    //ANALOG STICKS
    LeftX,
    LeftY,
    RightX,
    RightY,

    //MOUSE AXES
    MouseX,
    MouseY,

    //MOUSE BUTTONS
    LeftButton,
    RightButton,
    MiddleButton,
    XButton1,
    XButton2,

}

public static class InputHelper
{
    static Vector2 MouseDelta = default;
    public static Vector2 MousePosition = default;

    public static void PollMouse(MouseState state)
    {
        var position = new Vector2(state.X, state.Y);
        MouseDelta = position - MousePosition;
        MousePosition = position;
    }

    public static bool AnyPressed(KeyboardState keyState, MouseState mouseState, GamePadState padState)
    {
        return
        keyState.GetPressedKeys().Length > 0 ||
        padState.IsButtonDown(Buttons.A) ||
        padState.IsButtonDown(Buttons.B) ||
        padState.IsButtonDown(Buttons.X) ||
        padState.IsButtonDown(Buttons.Y) ||
        padState.IsButtonDown(Buttons.Back) ||
        padState.IsButtonDown(Buttons.Start) ||
        padState.IsButtonDown(Buttons.LeftStick) ||
        padState.IsButtonDown(Buttons.RightStick) ||
        padState.IsButtonDown(Buttons.LeftShoulder) ||
        padState.IsButtonDown(Buttons.RightShoulder) ||
        padState.IsButtonDown(Buttons.DPadUp) ||
        padState.IsButtonDown(Buttons.DPadDown) ||
        padState.IsButtonDown(Buttons.DPadLeft) ||
        padState.IsButtonDown(Buttons.DPadRight) ||
        System.MathF.Abs(padState.ThumbSticks.Left.X) > 0.0f ||
        System.MathF.Abs(padState.ThumbSticks.Left.Y) > 0.0f ||
        System.MathF.Abs(padState.ThumbSticks.Right.X) > 0.0f ||
        System.MathF.Abs(padState.ThumbSticks.Right.Y) > 0.0f ||
        System.MathF.Abs(MouseDelta.X) > 0.0f ||
        System.MathF.Abs(MouseDelta.Y) > 0.0f ||
        (mouseState.LeftButton == ButtonState.Pressed) ||
        (mouseState.RightButton == ButtonState.Pressed) ||
        (mouseState.MiddleButton == ButtonState.Pressed) ||
        (mouseState.XButton1 == ButtonState.Pressed) ||
        (mouseState.XButton2 == ButtonState.Pressed) ||
        false;
    }


    public static float Poll(KeyboardState keyState, MouseState mouseState, GamePadState padState, GenericInputs input)
    {
        switch (input)
        {

            case GenericInputs.A:
                if (keyState.IsKeyDown(Keys.A)) return 1.0f;
                break;

            case GenericInputs.B:
                if (keyState.IsKeyDown(Keys.B)) return 1.0f;
                break;

            case GenericInputs.C:
                if (keyState.IsKeyDown(Keys.C)) return 1.0f;
                break;

            case GenericInputs.D:
                if (keyState.IsKeyDown(Keys.D)) return 1.0f;
                break;

            case GenericInputs.E:
                if (keyState.IsKeyDown(Keys.E)) return 1.0f;
                break;

            case GenericInputs.F:
                if (keyState.IsKeyDown(Keys.F)) return 1.0f;
                break;

            case GenericInputs.G:
                if (keyState.IsKeyDown(Keys.G)) return 1.0f;
                break;

            case GenericInputs.H:
                if (keyState.IsKeyDown(Keys.H)) return 1.0f;
                break;

            case GenericInputs.I:
                if (keyState.IsKeyDown(Keys.I)) return 1.0f;
                break;

            case GenericInputs.J:
                if (keyState.IsKeyDown(Keys.J)) return 1.0f;
                break;

            case GenericInputs.K:
                if (keyState.IsKeyDown(Keys.K)) return 1.0f;
                break;

            case GenericInputs.L:
                if (keyState.IsKeyDown(Keys.L)) return 1.0f;
                break;

            case GenericInputs.M:
                if (keyState.IsKeyDown(Keys.M)) return 1.0f;
                break;

            case GenericInputs.N:
                if (keyState.IsKeyDown(Keys.N)) return 1.0f;
                break;

            case GenericInputs.O:
                if (keyState.IsKeyDown(Keys.O)) return 1.0f;
                break;

            case GenericInputs.P:
                if (keyState.IsKeyDown(Keys.P)) return 1.0f;
                break;

            case GenericInputs.Q:
                if (keyState.IsKeyDown(Keys.Q)) return 1.0f;
                break;

            case GenericInputs.R:
                if (keyState.IsKeyDown(Keys.R)) return 1.0f;
                break;

            case GenericInputs.S:
                if (keyState.IsKeyDown(Keys.S)) return 1.0f;
                break;

            case GenericInputs.T:
                if (keyState.IsKeyDown(Keys.T)) return 1.0f;
                break;

            case GenericInputs.U:
                if (keyState.IsKeyDown(Keys.U)) return 1.0f;
                break;

            case GenericInputs.V:
                if (keyState.IsKeyDown(Keys.V)) return 1.0f;
                break;

            case GenericInputs.W:
                if (keyState.IsKeyDown(Keys.W)) return 1.0f;
                break;

            case GenericInputs.X:
                if (keyState.IsKeyDown(Keys.X)) return 1.0f;
                break;

            case GenericInputs.Y:
                if (keyState.IsKeyDown(Keys.Y)) return 1.0f;
                break;

            case GenericInputs.Z:
                if (keyState.IsKeyDown(Keys.Z)) return 1.0f;
                break;

            case GenericInputs.D1:
                if (keyState.IsKeyDown(Keys.D1)) return 1.0f;
                break;

            case GenericInputs.D2:
                if (keyState.IsKeyDown(Keys.D2)) return 1.0f;
                break;

            case GenericInputs.D3:
                if (keyState.IsKeyDown(Keys.D3)) return 1.0f;
                break;

            case GenericInputs.D4:
                if (keyState.IsKeyDown(Keys.D4)) return 1.0f;
                break;

            case GenericInputs.D5:
                if (keyState.IsKeyDown(Keys.D5)) return 1.0f;
                break;

            case GenericInputs.D6:
                if (keyState.IsKeyDown(Keys.D6)) return 1.0f;
                break;

            case GenericInputs.D7:
                if (keyState.IsKeyDown(Keys.D7)) return 1.0f;
                break;

            case GenericInputs.D8:
                if (keyState.IsKeyDown(Keys.D8)) return 1.0f;
                break;

            case GenericInputs.D9:
                if (keyState.IsKeyDown(Keys.D9)) return 1.0f;
                break;

            case GenericInputs.D0:
                if (keyState.IsKeyDown(Keys.D0)) return 1.0f;
                break;

            case GenericInputs.Enter:
                if (keyState.IsKeyDown(Keys.Enter)) return 1.0f;
                break;

            case GenericInputs.Escape:
                if (keyState.IsKeyDown(Keys.Escape)) return 1.0f;
                break;

            case GenericInputs.Back:
                if (keyState.IsKeyDown(Keys.Back)) return 1.0f;
                break;

            case GenericInputs.Tab:
                if (keyState.IsKeyDown(Keys.Tab)) return 1.0f;
                break;

            case GenericInputs.Space:
                if (keyState.IsKeyDown(Keys.Space)) return 1.0f;
                break;

            case GenericInputs.OemMinus:
                if (keyState.IsKeyDown(Keys.OemMinus)) return 1.0f;
                break;

            case GenericInputs.OemCloseBrackets:
                if (keyState.IsKeyDown(Keys.OemCloseBrackets)) return 1.0f;
                break;

            case GenericInputs.OemOpenBrackets:
                if (keyState.IsKeyDown(Keys.OemOpenBrackets)) return 1.0f;
                break;

            case GenericInputs.OemBackslash:
                if (keyState.IsKeyDown(Keys.OemBackslash)) return 1.0f;
                break;

            case GenericInputs.OemSemicolon:
                if (keyState.IsKeyDown(Keys.OemSemicolon)) return 1.0f;
                break;

            case GenericInputs.OemQuotes:
                if (keyState.IsKeyDown(Keys.OemQuotes)) return 1.0f;
                break;

            case GenericInputs.OemTilde:
                if (keyState.IsKeyDown(Keys.OemTilde)) return 1.0f;
                break;

            case GenericInputs.OemComma:
                if (keyState.IsKeyDown(Keys.OemComma)) return 1.0f;
                break;

            case GenericInputs.OemPeriod:
                if (keyState.IsKeyDown(Keys.OemPeriod)) return 1.0f;
                break;

            case GenericInputs.BrowserForward:
                if (keyState.IsKeyDown(Keys.BrowserForward)) return 1.0f;
                break;

            case GenericInputs.CapsLock:
                if (keyState.IsKeyDown(Keys.CapsLock)) return 1.0f;
                break;

            case GenericInputs.F1:
                if (keyState.IsKeyDown(Keys.F1)) return 1.0f;
                break;

            case GenericInputs.F2:
                if (keyState.IsKeyDown(Keys.F2)) return 1.0f;
                break;

            case GenericInputs.F3:
                if (keyState.IsKeyDown(Keys.F3)) return 1.0f;
                break;

            case GenericInputs.F4:
                if (keyState.IsKeyDown(Keys.F4)) return 1.0f;
                break;

            case GenericInputs.F5:
                if (keyState.IsKeyDown(Keys.F5)) return 1.0f;
                break;

            case GenericInputs.F6:
                if (keyState.IsKeyDown(Keys.F6)) return 1.0f;
                break;

            case GenericInputs.F7:
                if (keyState.IsKeyDown(Keys.F7)) return 1.0f;
                break;

            case GenericInputs.F8:
                if (keyState.IsKeyDown(Keys.F8)) return 1.0f;
                break;

            case GenericInputs.F9:
                if (keyState.IsKeyDown(Keys.F9)) return 1.0f;
                break;

            case GenericInputs.F10:
                if (keyState.IsKeyDown(Keys.F10)) return 1.0f;
                break;

            case GenericInputs.F11:
                if (keyState.IsKeyDown(Keys.F11)) return 1.0f;
                break;

            case GenericInputs.F12:
                if (keyState.IsKeyDown(Keys.F12)) return 1.0f;
                break;

            case GenericInputs.PrintScreen:
                if (keyState.IsKeyDown(Keys.PrintScreen)) return 1.0f;
                break;

            case GenericInputs.Scroll:
                if (keyState.IsKeyDown(Keys.Scroll)) return 1.0f;
                break;

            case GenericInputs.Pause:
                if (keyState.IsKeyDown(Keys.Pause)) return 1.0f;
                break;

            case GenericInputs.Insert:
                if (keyState.IsKeyDown(Keys.Insert)) return 1.0f;
                break;

            case GenericInputs.Home:
                if (keyState.IsKeyDown(Keys.Home)) return 1.0f;
                break;

            case GenericInputs.PageUp:
                if (keyState.IsKeyDown(Keys.PageUp)) return 1.0f;
                break;

            case GenericInputs.Delete:
                if (keyState.IsKeyDown(Keys.Delete)) return 1.0f;
                break;

            case GenericInputs.End:
                if (keyState.IsKeyDown(Keys.End)) return 1.0f;
                break;

            case GenericInputs.PageDown:
                if (keyState.IsKeyDown(Keys.PageDown)) return 1.0f;
                break;

            case GenericInputs.Right:
                if (keyState.IsKeyDown(Keys.Right)) return 1.0f;
                break;

            case GenericInputs.Left:
                if (keyState.IsKeyDown(Keys.Left)) return 1.0f;
                break;

            case GenericInputs.Down:
                if (keyState.IsKeyDown(Keys.Down)) return 1.0f;
                break;

            case GenericInputs.Up:
                if (keyState.IsKeyDown(Keys.Up)) return 1.0f;
                break;

            case GenericInputs.NumLock:
                if (keyState.IsKeyDown(Keys.NumLock)) return 1.0f;
                break;

            case GenericInputs.Divide:
                if (keyState.IsKeyDown(Keys.Divide)) return 1.0f;
                break;

            case GenericInputs.Multiply:
                if (keyState.IsKeyDown(Keys.Multiply)) return 1.0f;
                break;

            case GenericInputs.OemPlus:
                if (keyState.IsKeyDown(Keys.OemPlus)) return 1.0f;
                break;

            case GenericInputs.NumPad1:
                if (keyState.IsKeyDown(Keys.NumPad1)) return 1.0f;
                break;

            case GenericInputs.NumPad2:
                if (keyState.IsKeyDown(Keys.NumPad2)) return 1.0f;
                break;

            case GenericInputs.NumPad3:
                if (keyState.IsKeyDown(Keys.NumPad3)) return 1.0f;
                break;

            case GenericInputs.NumPad4:
                if (keyState.IsKeyDown(Keys.NumPad4)) return 1.0f;
                break;

            case GenericInputs.NumPad5:
                if (keyState.IsKeyDown(Keys.NumPad5)) return 1.0f;
                break;

            case GenericInputs.NumPad6:
                if (keyState.IsKeyDown(Keys.NumPad6)) return 1.0f;
                break;

            case GenericInputs.NumPad7:
                if (keyState.IsKeyDown(Keys.NumPad7)) return 1.0f;
                break;

            case GenericInputs.NumPad8:
                if (keyState.IsKeyDown(Keys.NumPad8)) return 1.0f;
                break;

            case GenericInputs.NumPad9:
                if (keyState.IsKeyDown(Keys.NumPad9)) return 1.0f;
                break;

            case GenericInputs.NumPad0:
                if (keyState.IsKeyDown(Keys.NumPad0)) return 1.0f;
                break;

            case GenericInputs.LeftControl:
                if (keyState.IsKeyDown(Keys.LeftControl)) return 1.0f;
                break;

            case GenericInputs.LeftShift:
                if (keyState.IsKeyDown(Keys.LeftShift)) return 1.0f;
                break;

            case GenericInputs.LeftAlt:
                if (keyState.IsKeyDown(Keys.LeftAlt)) return 1.0f;
                break;

            case GenericInputs.RightControl:
                if (keyState.IsKeyDown(Keys.RightControl)) return 1.0f;
                break;

            case GenericInputs.RightShift:
                if (keyState.IsKeyDown(Keys.RightShift)) return 1.0f;
                break;

            case GenericInputs.RightAlt
:
                if (keyState.IsKeyDown(Keys.RightAlt
    )) return 1.0f;
                break;

            case GenericInputs.AButton:
                if (padState.IsButtonDown(Buttons.A)) return 1.0f;
                break;

            case GenericInputs.BButton:
                if (padState.IsButtonDown(Buttons.B)) return 1.0f;
                break;

            case GenericInputs.XButton:
                if (padState.IsButtonDown(Buttons.X)) return 1.0f;
                break;

            case GenericInputs.YButton:
                if (padState.IsButtonDown(Buttons.Y)) return 1.0f;
                break;

            case GenericInputs.BackButton:
                if (padState.IsButtonDown(Buttons.Back)) return 1.0f;
                break;

            case GenericInputs.StartButton:
                if (padState.IsButtonDown(Buttons.Start)) return 1.0f;
                break;

            case GenericInputs.LeftStick:
                if (padState.IsButtonDown(Buttons.LeftStick)) return 1.0f;
                break;

            case GenericInputs.RightStick:
                if (padState.IsButtonDown(Buttons.RightStick)) return 1.0f;
                break;

            case GenericInputs.LeftShoulder:
                if (padState.IsButtonDown(Buttons.LeftShoulder)) return 1.0f;
                break;

            case GenericInputs.RightShoulder:
                if (padState.IsButtonDown(Buttons.RightShoulder)) return 1.0f;
                break;

            case GenericInputs.DPadUp:
                if (padState.IsButtonDown(Buttons.DPadUp)) return 1.0f;
                break;

            case GenericInputs.DPadDown:
                if (padState.IsButtonDown(Buttons.DPadDown)) return 1.0f;
                break;

            case GenericInputs.DPadLeft:
                if (padState.IsButtonDown(Buttons.DPadLeft)) return 1.0f;
                break;

            case GenericInputs.DPadRight:
                if (padState.IsButtonDown(Buttons.DPadRight)) return 1.0f;
                break;

            case GenericInputs.LeftX:
                var LeftXValue = padState.ThumbSticks.Left.X;
                if (System.MathF.Abs(LeftXValue) > 0.0f)
                    return LeftXValue;
                break;

            case GenericInputs.LeftY:
                var LeftYValue = padState.ThumbSticks.Left.Y;
                if (System.MathF.Abs(LeftYValue) > 0.0f)
                    return LeftYValue;
                break;

            case GenericInputs.RightX:
                var RightXValue = padState.ThumbSticks.Right.X;
                if (System.MathF.Abs(RightXValue) > 0.0f)
                    return RightXValue;
                break;

            case GenericInputs.RightY:
                var RightYValue = padState.ThumbSticks.Right.Y;
                if (System.MathF.Abs(RightYValue) > 0.0f)
                    return RightYValue;
                break;

            case GenericInputs.MouseX:
                if (System.MathF.Abs(MouseDelta.X) > 0.0f)
                    return MouseDelta.X;
                break;

            case GenericInputs.MouseY:
                if (System.MathF.Abs(MouseDelta.Y) > 0.0f)
                    return MouseDelta.Y;
                break;

            case GenericInputs.LeftButton:
                if (mouseState.LeftButton == ButtonState.Pressed) return 1.0f;
                break;

            case GenericInputs.RightButton:
                if (mouseState.RightButton == ButtonState.Pressed) return 1.0f;
                break;

            case GenericInputs.MiddleButton:
                if (mouseState.MiddleButton == ButtonState.Pressed) return 1.0f;
                break;

            case GenericInputs.XButton1:
                if (mouseState.XButton1 == ButtonState.Pressed) return 1.0f;
                break;

            case GenericInputs.XButton2:
                if (mouseState.XButton2 == ButtonState.Pressed) return 1.0f;
                break;

        }

        return 0.0f;
    }
}