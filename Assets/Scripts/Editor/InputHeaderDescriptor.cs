using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using Ludiq;
using System;

[Descriptor(typeof(InputHeaderNode))]
public class InputHeaderDescriptor : UnitDescriptor<InputHeaderNode>
{
    public InputHeaderDescriptor(InputHeaderNode unit) : base(unit) { }

    protected override EditorTexture DefinedIcon()
    {
        switch (unit.CalcType)
        {
            case InputHeaderNode.CalculateType.Add:
                return typeof(Bolt.Add<int>).Icon();
            case InputHeaderNode.CalculateType.Multiply:
                return typeof(Bolt.Multiply<int>).Icon();
            default:
                return base.DefinedIcon();
        }
    }
}
