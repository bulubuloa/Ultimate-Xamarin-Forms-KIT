using System.ComponentModel;
using iOSCharts;
using UltimateXF.iOS.Renderers.Extendeds;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(SupportBarChartExtended), typeof(SupportBarChartExtendedRenderer))]
namespace UltimateXF.iOS.Renderers.Extendeds
{
    public class SupportBarChartExtendedRenderer : SupportBarLineChartBaseExtendedRenderer<SupportBarChartExtended, BarChartView>
    {
        public SupportBarChartExtendedRenderer()
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

                OriginalChartView.ReloadInputViews();
                OriginalChartView.SetNeedsDisplay();
            }
        }
    }
}