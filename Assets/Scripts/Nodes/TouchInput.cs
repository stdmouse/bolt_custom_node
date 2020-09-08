using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ludiq;
using Bolt;
using System;

namespace Rachlab
{
    [UnitCategory("RachLab\\TouchInput")]
    [RenamedFrom("Bolt.Addons.Rachlab.TouchInput")]
    [UnitTitle("TouchInput")]
    [TypeIcon(typeof(ISelectUnit))]
    public class TouchInput : Unit
    {
        public TouchInput() : base() { }

        [DoNotSerialize]
        public ControlInput enter { get; private set; }

        [DoNotSerialize]
        public ValueInput camera { get; private set; }

        [DoNotSerialize]
        [PortLabel("Up")]
        public ControlOutput up { get; private set; }

        [DoNotSerialize]
        [PortLabel("Keep")]
        public ControlOutput keep { get; private set; }

        [DoNotSerialize]
        [PortLabel("Down")]
        public ControlOutput down { get; private set; }

        [DoNotSerialize]
        public ValueOutput position { get; private set; }

        protected override void Definition()
        {
            enter = ControlInput(nameof(enter), Enter);
            camera = ValueInput<Camera>(nameof(camera));

            up = ControlOutput(nameof(up));
            keep = ControlOutput(nameof(keep));
            down = ControlOutput(nameof(down));

            position = ValueOutput<Vector2>(nameof(position), (flow) => GetPosition(flow));

            Succession(enter, down);
            Succession(enter, keep);
            Succession(enter, up);

            Requirement(camera, enter);
            Assignment(enter, position);
        }

        private ControlOutput Enter(Flow flow)
        {
#if (UNITY_EDITOR || UNITY_STANDALONE_WIN)
            if (Input.GetMouseButtonDown(0))
            {
                return down;
            }
            else if (Input.GetMouseButton(0))
            {
                return keep;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                return up;
            }
#else
            if (Input.touchCount > 0) {
                switch (Input.GetTouch(0).phase) {
                    case TouchPhase.Began:
                        return down;
                    case TouchPhase.Moved:
                    case TouchPhase.Stationary:
                        return keep;
                    case TouchPhase.Canceled:
                    case TouchPhase.Ended:
                        return up;
                    default:
                        break;
                }
            }
#endif

            return null;
        }

        private Vector2 GetPosition(Flow flow)
        {
            var camera = flow.GetValue(this.camera) as Camera;

#if (UNITY_EDITOR || UNITY_STANDALONE_WIN)
            return camera.ScreenToWorldPoint((Vector2)Input.mousePosition);
#else
            return camera.ScreenToWorldPoint(Input.GetTouch(0).position);
#endif
        }
    }
}