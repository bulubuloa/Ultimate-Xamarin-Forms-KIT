using System;
namespace UltimateXF.Widget.Charts.Models.Component
{
    public class XAxisConfig : AxisConfigBase
    {
        public int? LabelWidth { set; get; }
        public int? LabelHeight { set; get; }
        public XAXISPosition? XAXISPosition { set; get; }
        public float? LabelRotationAngle { set; get; }
        public bool? AvoidFirstLastClipping { set; get; }

        public XAxisConfig()
        {
        }
    }
}