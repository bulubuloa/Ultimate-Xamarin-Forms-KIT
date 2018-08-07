using System;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.CandleStickChart
{
    public interface ICandleStickDataSet : IBaseDataSet<CandleStickEntry>
    {
        Color IF_GetDecreasingColor();
        Color IF_GetIncreasingColor();
        Color IF_GetHighLightColor();
    }
}