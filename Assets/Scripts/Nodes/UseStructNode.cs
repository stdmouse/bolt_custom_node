using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rachlab.Entity;
using Bolt;
using Ludiq;

[UnitCategory("RachLab")]
public class UseStructNode : Unit
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
        inputValue = ValueInput<SampleStruct>(nameof(inputValue));

        exit = ControlOutput(nameof(exit));
        outputValue = ValueOutput<SampleStruct>(nameof(outputValue), GetOutput);

        Succession(enter, exit);
        Requirement(inputValue, enter);
        Requirement(inputValue, outputValue);
    }

    private ControlOutput Enter(Flow flow)
    {
        return exit;
    }

    private SampleStruct GetOutput(Flow flow)
    {
        var input = flow.GetValue<SampleStruct>(inputValue);
        var result = new SampleStruct();
        result.Id = input.Id + 1;
        result.Name = "output_" + input.Name;

        return result;
    }
}
