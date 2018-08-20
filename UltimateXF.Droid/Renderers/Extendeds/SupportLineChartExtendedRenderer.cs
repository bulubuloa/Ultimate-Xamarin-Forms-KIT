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
                OriginalChartView.Data = Export.ExportLineData(SupportChartView.ChartData);
                OriginalChartView.Invalidate();
            }
        }
    }
}