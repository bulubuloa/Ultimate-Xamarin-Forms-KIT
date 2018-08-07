using System;
namespace UltimateXF.Widget.Charts.Models
{
    public class EntryChart : BaseEntry
    {
        protected float XPosition = 0f;
        protected float YPosition = 0f;

        public EntryChart(float _XPosition, float _YPositioon)
        {
            XPosition = _XPosition;
            YPosition = _YPositioon;
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