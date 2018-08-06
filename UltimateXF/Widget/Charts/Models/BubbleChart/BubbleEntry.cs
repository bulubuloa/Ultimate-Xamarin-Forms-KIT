using System;
namespace UltimateXF.Widget.Charts.Models.BubbleChart
{
    public class BubbleEntry : BaseEntry
    {
        protected float XPosition = 0f;
        protected float Size = 0f;

        public BubbleEntry(float _XPosition, float _YPositioon, float _Size) : base(_YPositioon)
        {
            XPosition = _XPosition;
            YPosition = _YPositioon;
            Size = _Size;
        }

        public float GetXPosition()
        {
            return XPosition;
        }

        public float GetSize()
        {
            return Size;
        }
    }
}