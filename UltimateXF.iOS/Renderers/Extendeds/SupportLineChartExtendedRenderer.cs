using System.ComponentModel;
using iOSCharts;
using UltimateXF.iOS.Renderers.Extendeds;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(SupportLineChartExtended), typeof(SupportLineChartExtendedRenderer))]
namespace UltimateXF.iOS.Renderers.Extendeds
{
    public class SupportLineChartExtendedRenderer : SupportBarLineChartBaseExtendedRenderer<SupportLineChartExtended,LineChartView>
    {
        public SupportLineChartExtendedRenderer()
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
            if(OriginalChartView!=null && SupportChartView!=null && SupportChartView.ChartData!=null)
            {
                
                OriginalChartView.Data = Export.ExportLineData(SupportChartView.ChartData);
                OriginalChartView.ReloadInputViews();
                OriginalChartView.SetNeedsDisplay();
            }
        }
    }
}