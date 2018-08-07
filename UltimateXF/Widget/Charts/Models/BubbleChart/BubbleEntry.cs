using System;
namespace UltimateXF.Widget.Charts.Models.BubbleChart
{
    public class BubbleEntry : EntryChart
    {
        protected float Size = 0f;

        public BubbleEntry(float _XPosition, float _YPositioon, float _Size) : base(_XPosition,_YPositioon)
        {
            XPosition = _XPosition;
            YPosition = _YPositioon;
            Size = _Size;
        }

        public float GetSize()
        {
            return Size;
        }
    }
}