using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using Ludiq;

[UnitCategory("RachLab")]
//[UnitSurtitle("アイコン確認")]
[UnitTitle("Node")]
//[UnitSubtitle("アイコン確認用のノードです")]
//[UnitShortTitle ("アイコン")]
//[UnitOrder(10)]
//[TypeIcon(typeof(ISelectUnit))]
//[TypeIcon(typeof(Null))]
//[TypeIcon(typeof(Sequence))]
//[TypeIcon(typeof(Transform))]
//[TypeIcon(typeof(Rigidbody))]
//[TypeIcon(typeof(Vector3))]
//[TypeIcon(typeof(Vector2))]
//[TypeIcon(typeof(BoxCollider))]
//[TypeIcon(typeof(Avatar))]
//[TypeIcon(typeof(IList))]
//[TypeIcon(typeof(IDictionary))]
//[TypeIcon(typeof(Object))]
//[TypeIcon(typeof(int))]
//[TypeIcon(typeof(bool))]
//[TypeIcon(typeof(Bolt.Flow))]
//[TypeIcon(typeof(Bolt.Comparison))]
//[TypeIcon(typeof(Bolt.And))]
//[TypeIcon(typeof(Bolt.IEventUnit))]
//[TypeIcon(typeof(Bolt.IState))]
//[TypeIcon(typeof(Bolt.Less))]
//[TypeIcon(typeof(Bolt.ToggleFlow))]
public class NodeIconSampleNode : Unit
{
    //[DoNotSerialize]
    ////[PortLabelHidden]
    //public ControlInput enter { get; private set; }

    [DoNotSerialize]
    //[PortLabel("入力値")]
    public ValueInput inputValue { get; private set; }

    //[DoNotSerialize]
    ////[PortLabelHidden]
    //public ControlOutput exit { get; private set; }

    [DoNotSerialize]
    public ValueOutput outputValue { get; private set; }

    //[Serialize]
    //[Inspectable]
    ////[InspectorLabel("変数名")]
    ////[InspectorRange(0,10)]
    //[InspectorWide]
    //private int value;

    //[Serialize]
    //[Inspectable]
    //[InspectorToggleLeft]
    //private bool flug;

    [Serialize]
    [Inspectable]
    [InspectorTextArea]
    private string message;

    protected override void Definition()
    {
        //enter = ControlInput(nameof(enter), Enter);
        inputValue = ValueInput<int>(nameof(inputValue));

        //exit = ControlOutput(nameof(exit));
        outputValue = ValueOutput<string>(nameof(outputValue), GetOutput);

        //Succession(enter, exit);
        //Requirement(inputValue, enter);
        Requirement(inputValue, outputValue);
    }

    //private ControlOutput Enter(Flow flow)
    //{
    //    //var input = flow.GetValue<int>(inputValue);
    //    //Debug.Log("value= " + value + ", inputValue=" + input);

    //    return exit;
    //}

    private string GetOutput(Flow flow)
    {
        return "";
    }
}
