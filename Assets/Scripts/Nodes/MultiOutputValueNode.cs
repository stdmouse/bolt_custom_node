using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using Ludiq;

[UnitCategory("RachLab")]
public class MultiOutputValueNode : Unit
{
    [DoNotSerialize]
    public ValueInput inputValue { get; private set; }

    [DoNotSerialize]
    public ValueOutput isPlus { get; private set; }
    [DoNotSerialize]
    public ValueOutput isMinus { get; private set; }
    [DoNotSerialize]
    public ValueOutput label { get; private set; }

    protected override void Definition()
    {
        inputValue = ValueInput<int>(nameof(inputValue));
        isPlus =
            ValueOutput<bool>(
                nameof(isPlus),
                (flow) => flow.GetValue<int>(inputValue) >= 0);
        isMinus =
            ValueOutput<bool>(
                nameof(isMinus),
                (flow) => flow.GetValue<int>(inputValue) < 0);
        label =
            ValueOutput<string>(nameof(label), GetLabel);

        Requirement(inputValue, isPlus);
        Requirement(inputValue, isMinus);
        Requirement(inputValue, label);
    }

    private string GetLabel(Flow flow)
    {
        var value = flow.GetValue<int>(inputValue);

        if(value >= 0)
        {
            return "plus";
        }
        else
        {
            return "minus";
        }
    }
}
