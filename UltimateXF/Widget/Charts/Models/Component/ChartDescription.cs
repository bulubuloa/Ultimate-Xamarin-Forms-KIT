using System;
namespace UltimateXF.Widget.Charts.Models.Component
{
    public class ChartDescription : ConfigBase
    {
        public string Text { set; get; }
        public PaintAlign? TextAlign { set; get; }

        public ChartDescription()
        {
        }
    }
}