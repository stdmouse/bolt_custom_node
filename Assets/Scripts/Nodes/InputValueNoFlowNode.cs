using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using Ludiq;

[UnitCategory("RachLab")]
public class InputValueNoFlowNode : Unit
{
    [DoNotSerialize]
    public ValueInput inputValue { get; private set; }

    [DoNotSerialize]
    public ValueOutput outputValue { get; private set; }

    protected override void Definition()
    {
        inputValue = ValueInput<int>(nameof(inputValue));
        outputValue = 
            ValueOutput<int>(
                nameof(outputValue), 
                (flow) => flow.GetValue<int>(inputValue) * 2);

        Requirement(inputValue, outputValue);
    }
}
