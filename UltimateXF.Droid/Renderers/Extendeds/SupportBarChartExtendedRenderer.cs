using System.ComponentModel;
using Android.Content;
using MikePhil.Charting.Charts;
using UltimateXF.Droid.Renderers.Extendeds;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(SupportBarChartExtended), typeof(SupportBarChartExtendedRenderer))]
namespace UltimateXF.Droid.Renderers.Extendeds
{
    public class SupportBarChartExtendedRenderer : SupportBarLineChartBaseExtendedRenderer<SupportBarChartExtended, BarChart>
    {
        public SupportBarChartExtendedRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(nameof(SupportBarChartExtended.ChartData)))
            {
                OnInitializeChartData();
            }
        }

        protected override void OnInitializeChartData()
        {
            base.OnInitializeChartData();
            if (OriginalChartView != null && SupportChartView != null && SupportChartView.ChartData != null)
            {
                OriginalChartView.Data = Export.ExportBarData(SupportChartView.ChartData);
                OriginalChartView.Invalidate();
            }
        }
    }
}