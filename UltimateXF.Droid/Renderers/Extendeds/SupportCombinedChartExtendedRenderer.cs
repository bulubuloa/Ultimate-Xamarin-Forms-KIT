using System;
using System.ComponentModel;
using Android.Content;
using MikePhil.Charting.Charts;
using MikePhil.Charting.Data;
using UltimateXF.Droid.Renderers.Extendeds;
using UltimateXF.Widget.Charts;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(SupportCombinedChartExtended), typeof(SupportCombinedChartExtendedRenderer))]
namespace UltimateXF.Droid.Renderers.Extendeds
{
    public class SupportCombinedChartExtendedRenderer : SupportBarLineChartBaseExtendedRenderer<SupportCombinedChartExtended, CombinedChart>
    {
        public SupportCombinedChartExtendedRenderer(Context context) : base(context)
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
                var combin = new CombinedData();

                if (data.BubbleChartData != null)
                    combin.SetData(Export.ExportBubbleData(data.BubbleChartData));

                if (data.LineChartData != null)
                    combin.SetData(Export.ExportLineData(data.LineChartData));
                
                if (data.BarChartData != null)
                    combin.SetData(Export.ExportBarData(data.BarChartData));

                if (data.ScatterChartData != null)
                    combin.SetData(Export.ExportScatterData(data.ScatterChartData));

                if (data.CandleStickChartData != null)
                    combin.SetData(Export.ExportCandleStickData(data.CandleStickChartData));
                
                OriginalChartView.Data = combin;
                OriginalChartView.Invalidate();
            }
        }
    }
}