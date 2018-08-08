using System;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.Component
{
    public abstract class ConfigBase
    {
        public bool? Enabled = true;
        public float? XOffset;
        public float? YOffset;
        public Font? Typeface;
        public float? TextSize;
        public int? TextColor;

        public ConfigBase()
        {

        }
    }
}