using System;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.PieChart
{
    public class PieEntry : BaseEntry
    {
        protected float Percent = 0f;
        protected string Text = "";

        public PieEntry(float _Percent, string _Text)
        {
            Percent = _Percent;
            Text = _Text;
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