using System;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.PieChart
{
    public class PieEntry : BaseEntry
    {
        protected Color ColorFill;
        protected float Percent = 0f;
        protected string Text = "";

        public PieEntry(float _YPosition, string _text, Color _ColorFill) : base(_YPosition)
        {
            ColorFill = _ColorFill;
            Percent = _YPosition;
            Text = _text;
        }

        public Color GetColorFill()
        {
            return ColorFill;
        }

        public float GetPercent()
        {
            return Percent;
        }

        public string GetText()
        {
            return Text;
        }
    }
}