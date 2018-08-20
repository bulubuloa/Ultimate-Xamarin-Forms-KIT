using System.ComponentModel;
using Android.Content;
using MikePhil.Charting.Charts;
using UltimateXF.Droid.Renderers.Extendeds;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(SupportBubbleChartExtended), typeof(SupportBubbleChartExtendedRenderer))]
namespace UltimateXF.Droid.Renderers.Extendeds
{
    public class SupportBubbleChartExtendedRenderer : SupportBarLineChartBaseExtendedRenderer<SupportBubbleChartExtended, BubbleChart>
    {
        public SupportBubbleChartExtendedRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(nameof(SupportBubbleChartExtended.ChartData)))
            {
                OnInitializeChartData();
            }
        }

        protected override void OnInitializeChartData()
        {
            base.OnInitializeChartData();
            if (OriginalChartView != null && SupportChartView != null && SupportChartView.ChartData != null)
            {
                OriginalChartView.Data = Export.ExportBubbleData(SupportChartView.ChartData);
                OriginalChartView.Invalidate();
            }
        }
    }
}