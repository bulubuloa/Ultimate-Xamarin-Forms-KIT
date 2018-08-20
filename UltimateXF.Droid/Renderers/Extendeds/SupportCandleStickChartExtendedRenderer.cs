using System.ComponentModel;
using Android.Content;
using MikePhil.Charting.Charts;
using UltimateXF.Droid.Renderers.Extendeds;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(SupportCandleStickChartExtended), typeof(SupportCandleStickChartExtendedRenderer))]
namespace UltimateXF.Droid.Renderers.Extendeds
{
    public class SupportCandleStickChartExtendedRenderer : SupportBarLineChartBaseExtendedRenderer<SupportCandleStickChartExtended, CandleStickChart>
    {
        public SupportCandleStickChartExtendedRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(nameof(SupportCandleStickChartExtended.ChartData)))
            {
                OnInitializeChartData();
            }
        }

        protected override void OnInitializeChartData()
        {
            base.OnInitializeChartData();
            if (OriginalChartView != null && SupportChartView != null && SupportChartView.ChartData != null)
            {

                OriginalChartView.Data = Export.ExportCandleStickData(SupportChartView.ChartData);
                OriginalChartView.Invalidate();
            }
        }
    }
}