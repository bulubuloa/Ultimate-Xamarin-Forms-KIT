using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using iOSCharts;
using UltimateXF.iOS.Renderers.Extendeds;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(SupportBubbleChartExtended), typeof(SupportBubbleChartExtendedRenderer))]
namespace UltimateXF.iOS.Renderers.Extendeds
{
    public class SupportBubbleChartExtendedRenderer : SupportBarLineChartBaseExtendedRenderer<SupportBubbleChartExtended, BubbleChartView>
    {
        public SupportBubbleChartExtendedRenderer()
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
                OriginalChartView.ReloadInputViews();
                OriginalChartView.SetNeedsDisplay();
            }
        }
    }
}