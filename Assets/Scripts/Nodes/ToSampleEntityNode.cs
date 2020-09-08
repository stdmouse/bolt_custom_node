using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using Ludiq;
using Rachlab.Entity;

[UnitCategory("RachLab\\Entity")]
public class ToSampleEntityNode : Unit
{

    [DoNotSerialize]
    public ValueInput id { get; private set; }

    [DoNotSerialize]
    public ValueInput name { get; private set; }

    [DoNotSerialize]
    public ValueOutput sampleEntity { get; private set; }

    protected override void Definition()
    {
        id = ValueInput<int>(nameof(id));
        name = ValueInput<string>(nameof(name));

        sampleEntity = ValueOutput<SampleEntity>(nameof(sampleEntity), GetOutput);

        Requirement(id, sampleEntity);
        Requirement(name, sampleEntity);
    }

    private SampleEntity GetOutput(Flow flow)
    {
        var idValue = flow.GetValue<int>(id);
        var nameValue = flow.GetValue<string>(name);

        return new SampleEntity(idValue, nameValue);
    }
}
