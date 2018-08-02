using System;
namespace UltimateXF.Widget.Charts.Models
{
    public class Entry : BaseEntry
    {
        protected float XPosition = 0f;

        public Entry(float _XPosition, float _YPositioon) : base(_YPositioon)
        {
            XPosition = _XPosition;
        }

        public float GetXPosition()
        {
            return XPosition;
        }

        public float GetYPosition()
        {
            return YPosition;
        }
    }
}