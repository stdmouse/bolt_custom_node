using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using Ludiq;

[UnitCategory("RachLab")]
public class InputHeaderNode : Unit
{
    public enum CalculateType { Add, Multiply }

    [Serialize]
    private CalculateType calcType;

    [DoNotSerialize]
    [Inspectable]
    [UnitHeaderInspectable("CalcType")]
    public CalculateType CalcType
    {
        get
        {
            return calcType;
        }
        set
        {
            calcType = value;
        }
    }

    [Serialize]
    private int inputCount;

    [DoNotSerialize]
    [Inspectable]
    [UnitHeaderInspectable("InputCount")]
    public int InputCount
    {
        get
        {
            return Mathf.Max(2, inputCount);
        }
        set
        {
            inputCount = Mathf.Clamp(value, 2, 10);
        }
    }

    [DoNotSerialize]
    public List<ValueInput> inputValues { get; private set; }

    [DoNotSerialize]
    public ValueOutput outputValue { get; private set; }

    protected override void Definition()
    {
        outputValue = ValueOutput<int>(nameof(outputValue), GetValue);

        inputValues = new List<ValueInput>();

        for (var i = 0; i < Mathf.Min(inputCount, 10); i++)
        {
            var input = ValueInput<int>(GetInputValueName(i));
            inputValues.Add(input);
            Requirement(input, outputValue);
        }
    }

    private int GetValue(Flow flow)
    {
        switch (calcType)
        {
            case CalculateType.Add:
                return AddAll(flow);
            case CalculateType.Multiply:
                return MultiplyAll(flow);
            default:
                return 0;
        }
    }

    private string GetInputValueName(int index)
    {
        return "Input_" + index;
    }

    private int AddAll(Flow flow)
    {
        int result = 0;

        for (var i = 0; i < Mathf.Min(inputCount, 10); i++)
        {
            var input = flow.GetValue<int>(inputValues[i]);
            result += input;
        }

        return result;
    }

    private int MultiplyAll(Flow flow)
    {
        int result = 1;

        for (var i = 0; i < Mathf.Min(inputCount, 10); i++)
        {
            var input = flow.GetValue<int>(inputValues[i]);
            result *= input;
        }

        return result;
    }
}
