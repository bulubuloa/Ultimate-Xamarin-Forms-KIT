using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models;
using UltimateXF.Widget.Charts.Models.BarChart;
using UltimateXF.Widget.Charts.Models.BubbleChart;
using UltimateXF.Widget.Charts.Models.CandleStickChart;
using UltimateXF.Widget.Charts.Models.CombinedChart;
using UltimateXF.Widget.Charts.Models.LineChart;
using UltimateXF.Widget.Charts.Models.ScatterChart;
using Xamarin.Forms;

namespace DemoXF
{
    public partial class CombinedChartPage : ContentPage
    {
        public CombinedChartPage()
        {
            InitializeComponent();

            var entries = new List<EntryChart>();
            entries.Add(new EntryChart(0, 5));
            entries.Add(new EntryChart(1, 7));
            entries.Add(new EntryChart(2, 10));
            entries.Add(new EntryChart(3, 3));
            entries.Add(new EntryChart(4, 1));
            entries.Add(new EntryChart(5, 7));
            entries.Add(new EntryChart(6, 2));

            var labels = new List<string>();
            labels.Add("col1");
            labels.Add("col2");
            labels.Add("col3");
            labels.Add("col4");
            labels.Add("col5");
            labels.Add("col6");
            labels.Add("col7");

            var scatterDataSet = new ScatterDataSet(entries, "Scatter DataSet")
            {
                DrawValue = true,
                DataColorScheme = new List<Color>(){
                    Color.Accent, Color.Azure, Color.Bisque, Color.Gray, Color.Green, Color.Chocolate, Color.Black
                }
            };
            var scatterChartData = new ScatterChartData(new List<IScatterDataSet>() { scatterDataSet }, labels);

            //line
            var lineDataSet = new LineDataSet(entries, "Line DataSet")
            {
                DrawValue = true,
                DataColorScheme = new List<Color>(){
                    Color.Accent, Color.Azure, Color.Bisque, Color.Gray, Color.Green, Color.Chocolate, Color.Black
                },
                DrawMode = LineDataSetMode.CUBIC_BEZIER,
            };
            var lineChartData = new LineChartData(new List<ILineDataSet>() { lineDataSet }, labels);

            //bubbed
            var bubbleEntries = new List<BubbleEntry>();
            bubbleEntries.Add(new BubbleEntry(0, 0, 0f));
            bubbleEntries.Add(new BubbleEntry(1, 50f, 3f));
            bubbleEntries.Add(new BubbleEntry(2, 10f, 5f));
            bubbleEntries.Add(new BubbleEntry(3, 30f, 1f));
            bubbleEntries.Add(new BubbleEntry(4, 20f, 2f));
            bubbleEntries.Add(new BubbleEntry(5, 15f, 4f));
            bubbleEntries.Add(new BubbleEntry(6, 0, 0f));
            var bubbleDataSet = new BubbleDataSet(bubbleEntries, "Bubble DataSet")
            {
                DrawValue = false,
                DataColorScheme = new List<Color>(){
                    Color.Accent, Color.Azure, Color.Bisque, Color.Gray, Color.Green, Color.Chocolate, Color.Black
                }
            };
            var bubbleChartData = new BubbleChartData(new List<IBubbleDataSet>() { bubbleDataSet }, labels);

            //barchar
            var barDataSet = new BarDataSet(entries, "Bar DataSet")
            {
                DrawValue = true,
                DataColorScheme = new List<Color>(){
                    Color.Accent, Color.Azure, Color.Bisque, Color.Gray, Color.Green, Color.Chocolate, Color.Black
                }
            };
            var barChartData = new BarChartData(new List<IBarDataSet>() { barDataSet }, labels);

            //candle
            var candleStickEntries = new List<CandleStickEntry>();
            candleStickEntries.Add(new CandleStickEntry(0, 4.62f, 2.02f, 2.70f, 4.13f));
            candleStickEntries.Add(new CandleStickEntry(1, 5.50f, 2.70f, 3.35f, 4.96f));
            candleStickEntries.Add(new CandleStickEntry(2, 5.25f, 3.02f, 3.50f, 4.50f));
            candleStickEntries.Add(new CandleStickEntry(3, 6f, 3.25f, 4.40f, 5.0f));
            candleStickEntries.Add(new CandleStickEntry(4, 5.57f, 2f, 2.80f, 4.5f));
            var stickDataSet = new CandleStickDataSet(candleStickEntries, "Candle DataSet")
            {
                DrawValue = true,
            };
            var stickChartData = new CandleStickChartData(new List<ICandleStickDataSet>() { stickDataSet }, labels);

            var combined = new CombinedChartData(null, labels)
            {
                BarChartData = barChartData,
                BubbleChartData = bubbleChartData,
                CandleStickChartData = stickChartData,
                LineChartData = lineChartData,
                ScatterChartData = scatterChartData
            };
            chart.ChartData = combined;
            chart2.ChartData = combined;
        }
    }
}
