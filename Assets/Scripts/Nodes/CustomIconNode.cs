using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ludiq;
using Bolt;

[UnitCategory("RachLab")]
public class CustomIconNode : Unit
{
    [DoNotSerialize]
    [PortLabelHidden]
    public ControlInput enter { get; private set; }

    [DoNotSerialize]
    [PortLabelHidden]
    public ControlOutput exit { get; private set; }

    protected override void Definition()
    {
        enter = ControlInput(nameof(enter), Enter);
        exit = ControlOutput(nameof(exit));

        Succession(enter, exit);
    }

    private ControlOutput Enter(Flow flow)
    {
        return exit;
    }
}