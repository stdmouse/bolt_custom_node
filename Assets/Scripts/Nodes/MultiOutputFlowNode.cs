using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using Ludiq;

[UnitCategory("RachLab")]
public class MultiOutputFlowNode : Unit
{
    [DoNotSerialize]
    [PortLabelHidden]
    public ControlInput enter { get; private set; }

    [DoNotSerialize]
    public ControlOutput up { get; private set; }

    [DoNotSerialize]
    public ControlOutput down { get; private set; }


    protected override void Definition()
    {
        enter = ControlInput(nameof(enter), InputKey);

        up = ControlOutput(nameof(up));
        down = ControlOutput(nameof(down));

        Succession(enter, up);
        Succession(enter, down);
    }

    private ControlOutput InputKey(Flow flow)
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            return up;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            return down;
        }

        return null;
    }
}
