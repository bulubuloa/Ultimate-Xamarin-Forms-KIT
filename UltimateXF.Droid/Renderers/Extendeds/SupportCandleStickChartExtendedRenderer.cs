using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Android.Content;
using MikePhil.Charting.Charts;
using UltimateXF.Droid.Renderers.Extendeds;
using UltimateXF.Widget.Charts;
using UltimateXF.Widget.Charts.Models.CandleStickChart;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

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
                var dataSetItems = SupportChartView.ChartData.DataSets;
                var listDataSetItems = new List<MikePhil.Charting.Data.CandleDataSet>();

                foreach (var itemChild in dataSetItems)
                {
                    var entryOriginal = itemChild.IF_GetValues().Select(item => new MikePhil.Charting.Data.CandleEntry(item.GetXPosition(), (float)item.GetHigh(), (float)item.GetLow(), (float)item.GetOpen(), (float)item.GetClose()));
                    var dataSet = new MikePhil.Charting.Data.CandleDataSet(entryOriginal.ToArray(), itemChild.IF_GetLabel());
                    OnIntializeDataSet(itemChild, dataSet);
                    listDataSetItems.Add(dataSet);
                }

                var data = new MikePhil.Charting.Data.CandleData(listDataSetItems.ToArray());
                OriginalChartView.Data = data;
                OriginalChartView.Invalidate();
            }
        }

        private Android.Graphics.Paint.Style ConvertPaintStyle(PaintStyle source)
        {
            switch (source)
            {
                case PaintStyle.STROKE:
                    return Android.Graphics.Paint.Style.Stroke;
                case PaintStyle.FILL_AND_STROKE:
                    return Android.Graphics.Paint.Style.FillAndStroke;
                default:
                    return Android.Graphics.Paint.Style.Fill;
            }
        }

        private void OnIntializeDataSet(ICandleStickDataSet source, MikePhil.Charting.Data.CandleDataSet original)
        {
            OnSettingsBarLineScatterCandleBubbleDataSet(source, original);

            if (source.IF_GetShadowWidth().HasValue)
                original.ShadowWidth = source.IF_GetShadowWidth().Value;

            if (source.IF_GetShowCandleBar().HasValue)
                original.ShowCandleBar = source.IF_GetShowCandleBar().Value;

            if (source.IF_GetBarSpace().HasValue)
                original.BarSpace = source.IF_GetBarSpace().Value;

            if (source.IF_GetShadowColorSameAsCandle().HasValue)
                original.ShadowColorSameAsCandle = source.IF_GetShadowColorSameAsCandle().Value;

            if (source.IF_GetIncreasingPaintStyle().HasValue)
                original.IncreasingPaintStyle = ConvertPaintStyle(source.IF_GetIncreasingPaintStyle().Value);

            if (source.IF_GetDecreasingPaintStyle().HasValue)
                original.DecreasingPaintStyle = ConvertPaintStyle(source.IF_GetDecreasingPaintStyle().Value);

            if (source.IF_GetNeutralColor().HasValue)
                original.NeutralColor = source.IF_GetNeutralColor().Value.ToAndroid();

            if (source.IF_GetDecreasingColor().HasValue)
                original.DecreasingColor = source.IF_GetDecreasingColor().Value.ToAndroid();

            if (source.IF_GetIncreasingColor().HasValue)
                original.IncreasingColor = source.IF_GetIncreasingColor().Value.ToAndroid();

            if (source.IF_GetShadowColor().HasValue)
                original.ShadowColor = source.IF_GetShadowColor().Value.ToAndroid();
        }
    }
}