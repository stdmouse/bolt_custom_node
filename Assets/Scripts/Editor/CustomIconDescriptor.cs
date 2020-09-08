using Bolt;
using Ludiq;
using UnityEngine;

[Descriptor(typeof(CustomIconNode))]
public class CustomIconDescriptor : UnitDescriptor<CustomIconNode>
{
    public CustomIconDescriptor(CustomIconNode unit) : base(unit) { }

    protected override EditorTexture DefinedIcon()
    {
        var texture = Resources.Load("icon_star") as Texture2D;

        return EditorTexture.Single(texture);
    }
}
