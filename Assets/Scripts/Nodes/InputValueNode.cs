using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using Ludiq;

[UnitCategory("RachLab")]
public class InputValueNode : Unit
{
    [DoNotSerialize]
    [PortLabelHidden]
    public ControlInput enter { get; private set; }

    [DoNotSerialize]
    public ValueInput inputValue { get; private set; }

    [DoNotSerialize]
    [PortLabelHidden]
    public ControlOutput exit { get; private set; }

    [DoNotSerialize]
    public ValueOutput outputValue { get; private set; }

    protected override void Definition()
    {
        enter = ControlInput(nameof(enter), Enter);
        inputValue = ValueInput<int>(nameof(inputValue));

        exit = ControlOutput(nameof(exit));
        outputValue =
            ValueOutput<Vector3>(nameof(outputValue), ToVector3);

        Succession(enter, exit);
        Requirement(inputValue, enter);
        Requirement(inputValue, outputValue);
    }

    private ControlOutput Enter(Flow flow)
    {
        var value = flow.GetValue<int>(this.inputValue);

        Debug.Log("value= " + value);

        return exit;
    }

    private Vector3 ToVector3(Flow flow)
    {
        var value = flow.GetValue<int>(inputValue);
        return new Vector3(value, value, value);
    }
}
