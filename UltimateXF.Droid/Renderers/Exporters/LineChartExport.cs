using System;
using System.Collections.Generic;
using System.Linq;
using UltimateXF.Widget.Charts.Models.LineChart;
using Xamarin.Forms.Platform.Android;

namespace UltimateXF.Droid.Renderers.Exporters
{
    public class LineChartExport
    {
        public MikePhil.Charting.Data.LineData Export(LineChartData ChartData)
        {
            var dataSetItems = new List<MikePhil.Charting.Data.LineDataSet>();

            foreach (var itemChild in ChartData.IF_GetDataSet())
            {
                var entryOriginal = itemChild.IF_GetEntry().Select(item => new MikePhil.Charting.Data.Entry(item.GetXPosition(), item.GetYPosition()));
                var dataSet = new MikePhil.Charting.Data.LineDataSet(entryOriginal.ToArray(), itemChild.IF_GetTitle());

                if (itemChild.IF_GetDataColorScheme() != null)
                    dataSet.SetColors(itemChild.IF_GetDataColorScheme().Select(item => item.ToAndroid().ToArgb()).ToArray());
                

                IntializeDataSet(itemChild, dataSet);
                dataSetItems.Add(dataSet);
            }

            var data = new MikePhil.Charting.Data.LineData(dataSetItems.ToArray());
            return data;
        }

        private void IntializeDataSet(ILineDataSet source, MikePhil.Charting.Data.LineDataSet original)
        {
            if (source.IF_GetDrawMode().HasValue)
                original.SetMode(SupportChart.GetDrawLineMode(source.IF_GetDrawMode().Value));

            if (source.IF_GetCircleRadius().HasValue)
                original.CircleRadius = source.IF_GetCircleRadius().Value;

            if (source.IF_GetCircleHoleRadius().HasValue)
                original.CircleHoleRadius = source.IF_GetCircleHoleRadius().Value;

            if (source.IF_GetDrawCircle().HasValue)
                original.SetDrawCircles(source.IF_GetDrawCircle().Value);

            if (source.IF_GetCircleColors().Count > 0)
                original.SetCircleColors(source.IF_GetCircleColors().Select(item => item.ToAndroid().ToArgb()).ToArray());

            if (source.IF_GetDrawFilled().HasValue)
                original.SetDrawFilled(source.IF_GetDrawFilled().Value);

            if (source.IF_GetLineWidth().HasValue)
                original.LineWidth = source.IF_GetLineWidth().Value;
        }
    }
}