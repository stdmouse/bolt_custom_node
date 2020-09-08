using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using Ludiq;
using System;

[UnitCategory("RachLab")]
public class ThroughNode : Unit
{
    [DoNotSerialize]
    public ControlInput enter { get; private set; }

    [DoNotSerialize]
    public ControlOutput exit { get; private set; }

    protected override void Definition()
    {
        enter = ControlInput(nameof(enter), Enter);
        exit = ControlOutput(nameof(exit));

        Succession(enter, exit);
    }

    private ControlOutput Enter(Flow flow)
    {
        Debug.Log("スローが実行");

        return exit;
    }
}
