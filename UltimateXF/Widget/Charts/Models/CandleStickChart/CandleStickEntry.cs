using System;
namespace UltimateXF.Widget.Charts.Models.CandleStickChart
{
    public class CandleStickEntry : BaseEntry
    {
        protected float XPosition;
        protected float HighValue;
        protected float LowValue;
        protected float OpenValue;
        protected float CloseValue;

        public CandleStickEntry(float _XPosition, float _High, float _Low, float _Open, float _Close)
        {
            XPosition = _XPosition;
            HighValue = _High;
            LowValue = _Low;
            OpenValue = _Open;
            CloseValue = _Close;
        }

        public float GetXPosition()
        {
            return XPosition;
        }

        public float GetHigh()
        {
            return HighValue;
        }

        public float GetLow()
        {
            return LowValue;
        }

        public float GetOpen()
        {
            return OpenValue;
        }

        public float GetClose()
        {
            return CloseValue;
        }
    }
}