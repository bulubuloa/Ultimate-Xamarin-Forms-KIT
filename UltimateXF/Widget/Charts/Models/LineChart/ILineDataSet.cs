using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.LineChart
{
    public interface ILineDataSet : IBaseDataSet<EntryChart>
    {
        LineDataSetMode IF_GetDrawMode();
        float IF_GetCircleRadius();
        float IF_GetCircleHoleRadius();
        bool IF_GetDrawCircle();
        List<Color> IF_GetCircleColors();
        Color IF_GetCircleColor();
    }
}