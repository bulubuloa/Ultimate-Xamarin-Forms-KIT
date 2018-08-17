using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Android.Content;
using Android.Widget;
using MikePhil.Charting.Charts;
using UltimateXF.Droid.Renderers.Extendeds;
using UltimateXF.Widget.Charts;
using UltimateXF.Widget.Charts.Models.LineChart;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SupportLineChartExtended), typeof(SupportLineChartExtendedRenderer))]
namespace UltimateXF.Droid.Renderers.Extendeds
{
    public class SupportLineChartExtendedRenderer : SupportBarLineChartBaseExtendedRenderer<SupportLineChartExtended, LineChart>
    {
        public SupportLineChartExtendedRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(nameof(SupportLineChartExtended.ChartData)))
            {
                OnInitializeChartData();
            }
        }

        protected override void OnInitializeChartData()
        {
            base.OnInitializeChartData();
            if (OriginalChartView != null && SupportChartView != null && SupportChartView.ChartData != null)
            {
                var dataSetItems = new List<MikePhil.Charting.Data.LineDataSet>();
                foreach (var item in SupportChartView.ChartData.DataSetItems)
                {
                    var entryOriginal = item.IF_GetEntry().Select(obj => new MikePhil.Charting.Data.Entry(obj.GetXPosition(), obj.GetYPosition()));
                    var dataSet = new MikePhil.Charting.Data.LineDataSet(entryOriginal.ToArray(), item.IF_GetTitle());
                    if (item.IF_GetDataColorScheme() != null)
                    {
                        dataSet.SetColors(item.IF_GetDataColorScheme().Select(obj => obj.ToAndroid().ToArgb()).ToArray());
                    }
                    IntializeDataSet(item, dataSet);
                    dataSetItems.Add(dataSet);
                }
                var data = new MikePhil.Charting.Data.LineData(dataSetItems.ToArray());
                OriginalChartView.Data = data;
                OriginalChartView.Invalidate();
            }
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