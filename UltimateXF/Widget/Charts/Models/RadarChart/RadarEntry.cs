using System;
namespace UltimateXF.Widget.Charts.Models.RadarChart
{
    public class RadarEntry : BaseEntry
    {
        protected float Value;

        public RadarEntry(float _value)
        {
            Value = _value;
        }

        public float GetValue()
        {
            return Value;
        }
    }
}