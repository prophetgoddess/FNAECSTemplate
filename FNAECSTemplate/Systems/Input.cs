using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using FNAECSTemplate.Utility;
using MoonTools.ECS;
using System.Text;
using FNAECSTemplate.Messages;

namespace FNAECSTemplate.Systems;

public enum Actions
{
    ExampleAction
}

public enum ActionState
{
    Off,
    Pressed,
    Held,
    Released
}


public class GenericAxis
{
    public float Value;
    public HashSet<GenericInputs> Positive = new HashSet<GenericInputs>();
    public HashSet<GenericInputs> Negative = new HashSet<GenericInputs>();
}

public class Input : MoonTools.ECS.System
{

    public static Dictionary<Actions, GenericAxis> ActionBindings;

    public static string GetActionNames(Actions action)
    {
        var axis = ActionBindings[action];
        var results = new StringBuilder();

        int i = 0;
        results.Append("[");

        foreach (var input in axis.Positive)
        {
            if (axis.Negative.Count > 0)
            {
                results.Append("+");
            }
            results.Append(input);
            if (i < axis.Positive.Count - 1 || axis.Negative.Count > 0)
            {
                results.Append(",");
            }
            i++;
        }
        i = 0;


        foreach (var input in axis.Negative)
        {
            results.Append("-");
            results.Append(input);
            if (i < axis.Negative.Count - 1)
            {
                results.Append(",");
            }
            i++;
        }
        results.Append("]");

        return results.ToString();
    }

    Dictionary<Actions, ActionState> ActionStates = new Dictionary<Actions, ActionState>();

    public static void ResetActions()
    {
        ActionBindings = new Dictionary<Actions, GenericAxis>()
        {
            {Actions.ExampleAction, new GenericAxis{
                Positive = new HashSet<GenericInputs>(){GenericInputs.Space}
            }}
        };
    }

    public Input(World world) : base(world)
    {
        ResetActions();

        foreach (var n in (Actions[])System.Enum.GetValues(typeof(Actions)))
        {
            ActionStates[n] = ActionState.Off;
        }
    }

    public override void Update(System.TimeSpan delta)
    {
        var mouseState = Mouse.GetState();
        var keyState = Keyboard.GetState();
        var padState = GamePad.GetState(Microsoft.Xna.Framework.PlayerIndex.One);

        InputHelper.PollMouse(mouseState);

        Send(new MousePosition(InputHelper.MousePosition));

        foreach (var (action, axis) in ActionBindings)
        {
            var value = 0.0f;

            foreach (var input in axis.Positive)
            {
                var v = InputHelper.Poll(keyState, mouseState, padState, input);
                if (System.MathF.Abs(v) > 0.0f)
                {
                    value = v;

                    switch (ActionStates[action])
                    {
                        case ActionState.Off:
                            ActionStates[action] = ActionState.Pressed;
                            break;
                        case ActionState.Pressed:
                            ActionStates[action] = ActionState.Held;
                            break;
                        case ActionState.Held:
                            break;
                        case ActionState.Released:
                            ActionStates[action] = ActionState.Pressed;
                            break;
                    }
                    break;
                }
                else
                {
                    switch (ActionStates[action])
                    {
                        case ActionState.Off:
                            break;
                        case ActionState.Pressed:
                            ActionStates[action] = ActionState.Released;
                            break;
                        case ActionState.Held:
                            ActionStates[action] = ActionState.Released;
                            break;
                        case ActionState.Released:
                            ActionStates[action] = ActionState.Off;
                            break;
                    }
                }
            }

            foreach (var input in axis.Negative)
            {
                var v = InputHelper.Poll(keyState, mouseState, padState, input) * -1.0f;
                if (System.MathF.Abs(v) > 0.0f)
                {
                    value += v;
                    switch (ActionStates[action])
                    {
                        case ActionState.Off:
                            ActionStates[action] = ActionState.Pressed;
                            break;
                        case ActionState.Pressed:
                            ActionStates[action] = ActionState.Held;
                            break;
                        case ActionState.Held:
                            break;
                        case ActionState.Released:
                            ActionStates[action] = ActionState.Pressed;
                            break;
                    }
                    break;
                }
                else
                {
                    switch (ActionStates[action])
                    {
                        case ActionState.Off:
                            break;
                        case ActionState.Pressed:
                            ActionStates[action] = ActionState.Released;
                            break;
                        case ActionState.Held:
                            ActionStates[action] = ActionState.Released;
                            break;
                        case ActionState.Released:
                            ActionStates[action] = ActionState.Off;
                            break;
                    }
                }
            }

            if (System.MathF.Abs(value) > 0.0f)
            {
                Send(new InputAction(value, action, ActionStates[action]));
            }
        }
    }
}