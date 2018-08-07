using System;
namespace UltimateXF.Widget.Charts.Models.CandleStickChart
{
    public class CandleStickEntry : BaseEntry
    {
        protected float XPosition;
        protected double HighValue;
        protected double LowValue;
        protected double OpenValue;
        protected double CloseValue;

        public CandleStickEntry(float _XPosition, double _High, double _Low, double _Open, double _Close)
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

        public double GetHigh()
        {
            return HighValue;
        }

        public double GetLow()
        {
            return LowValue;
        }

        public double GetOpen()
        {
            return OpenValue;
        }

        public double GetClose()
        {
            return CloseValue;
        }
    }
}