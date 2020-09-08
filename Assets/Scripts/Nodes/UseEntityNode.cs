using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using Ludiq;
using Rachlab.Entity;

[UnitCategory("RachLab")]
public class UseEntityNode : Unit
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
        inputValue = ValueInput<SampleEntity>(nameof(inputValue));

        exit = ControlOutput(nameof(exit));
        outputValue = ValueOutput<SampleEntity>(nameof(outputValue), GetOutput);

        Succession(enter, exit);
        Requirement(inputValue, enter);
        Requirement(inputValue, outputValue);
    }

    private ControlOutput Enter(Flow flow)
    {
        return exit;
    }

    private SampleEntity GetOutput(Flow flow)
    {
        var input = flow.GetValue<SampleEntity>(inputValue);
        var result = new SampleEntity();
        result.Id = input.Id + 1;
        result.Name = "output_" + input.Name;

        return result;
    }
}
