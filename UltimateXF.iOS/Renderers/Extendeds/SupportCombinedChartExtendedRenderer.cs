using System;
using System.ComponentModel;
using iOSCharts;
using UltimateXF.iOS.Renderers.Extendeds;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(SupportCombinedChartExtended), typeof(SupportCombinedChartExtendedRenderer))]
namespace UltimateXF.iOS.Renderers.Extendeds
{
    public class SupportCombinedChartExtendedRenderer : SupportBarLineChartBaseExtendedRenderer<SupportCombinedChartExtended, CombinedChartView>
    {
        public SupportCombinedChartExtendedRenderer()
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
                var data = SupportChartView.ChartData;
                var combin = new CombinedChartData();

                if (data.BubbleChartData != null)
                    combin.BubbleData = (Export.ExportBubbleData(data.BubbleChartData));

                if (data.LineChartData != null)
                    combin.LineData = (Export.ExportLineData(data.LineChartData));

                if (data.BarChartData != null)
                    combin.BarData = (Export.ExportBarData(data.BarChartData));

                if (data.ScatterChartData != null)
                    combin.ScatterData = (Export.ExportScatterData(data.ScatterChartData));

                if (data.CandleStickChartData != null)
                    combin.CandleData = (Export.ExportCandleStickData(data.CandleStickChartData));

                OriginalChartView.Data = combin;
                OriginalChartView.ReloadInputViews();
                OriginalChartView.SetNeedsDisplay();
            }
        }
    }
}