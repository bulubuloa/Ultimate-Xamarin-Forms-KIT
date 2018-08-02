using System;
namespace UltimateXF.Widget.Charts.Models
{
    public abstract class BaseEntry
    {
        protected float YPosition = 0f;

        public BaseEntry()
        {
            
        }

        public BaseEntry(float _YPosition)
        {
            YPosition = _YPosition;
        }
    }
}