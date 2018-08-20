using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Android.Content;
using MikePhil.Charting.Charts;
using MikePhil.Charting.Data;
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
                var dataSetItems = new List<LineDataSet>();
                foreach (var item in SupportChartView.ChartData.DataSets)
                {
                    var entryOriginal = item.IF_GetValues().Select(obj => new MikePhil.Charting.Data.Entry(obj.GetXPosition(), obj.GetYPosition()));
                    var dataSet = new LineDataSet(entryOriginal.ToArray(), item.IF_GetLabel());
                    OnIntializeDataSet(item, dataSet);
                    dataSetItems.Add(dataSet);
                }
                var data = new LineData(dataSetItems.ToArray());
                OriginalChartView.Data = data;
                OriginalChartView.Invalidate();
            }
        }

        private void OnIntializeDataSet(ILineDataSetXF source, LineDataSet original)
        {
            OnSettingsLineRadarDataSet(source, original);

            if (source.IF_GetMode().HasValue)
                original.SetMode(GetDrawLineMode(source.IF_GetMode().Value));

            if (source.IF_GetCircleColors() != null && source.IF_GetCircleColors().Count > 0)
                original.SetCircleColors(source.IF_GetCircleColors().Select(item => item.ToAndroid().ToArgb()).ToArray());

            if (source.IF_GetCircleHoleColor().HasValue)
                original.SetCircleColorHole(source.IF_GetCircleHoleColor().Value.ToAndroid());

            if (source.IF_GetCircleRadius().HasValue)
                original.CircleRadius = source.IF_GetCircleRadius().Value;

            if (source.IF_GetCircleHoleRadius().HasValue)
                original.CircleHoleRadius = source.IF_GetCircleHoleRadius().Value;

            if (source.IF_GetCubicIntensity().HasValue)
                original.CubicIntensity = source.IF_GetCubicIntensity().Value;

            if (source.IF_GetDrawCircles().HasValue)
                original.SetDrawCircles(source.IF_GetDrawCircles().Value);

            if (source.IF_GetDrawCircleHole().HasValue)
                original.SetDrawCircleHole(source.IF_GetDrawCircleHole().Value);
        }
    }
}