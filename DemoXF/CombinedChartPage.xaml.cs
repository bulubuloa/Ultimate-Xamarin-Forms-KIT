using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models;
using UltimateXF.Widget.Charts.Models.BarChart;
using UltimateXF.Widget.Charts.Models.BubbleChart;
using UltimateXF.Widget.Charts.Models.CandleStickChart;
using UltimateXF.Widget.Charts.Models.CombinedChart;
using UltimateXF.Widget.Charts.Models.Formatters;
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

            var entrieLine = new List<EntryChart>();
            var entries = new List<BubbleEntry>();
            var entries2 = new List<BubbleEntry>();
            var labels = new List<string>();

            Random random = new Random();


            for (int i = 0; i < 8; i++)
            {
                entrieLine.Add(new EntryChart(i, random.Next(20)));
                entries.Add(new BubbleEntry(i, random.Next(8), random.Next(20)));
                entries2.Add(new BubbleEntry(i, random.Next(8), random.Next(20)));
                labels.Add("Entry" + i);
            }

            var entriesCandle = new List<CandleStickEntry>();
            entriesCandle.Add(new CandleStickEntry(0, 4.62f, 2.02f, 2.70f, 4.13f));
            entriesCandle.Add(new CandleStickEntry(1, 5.50f, 2.70f, 3.35f, 4.96f));
            entriesCandle.Add(new CandleStickEntry(2, 5.25f, 3.02f, 3.50f, 4.50f));
            entriesCandle.Add(new CandleStickEntry(3, 6f, 3.25f, 4.40f, 5.0f));
            entriesCandle.Add(new CandleStickEntry(4, 5.57f, 2f, 2.80f, 4.5f));

            var dataSetBubble = new BubbleDataSet(entries, "Bubble DataSet 1")
            {
                Colors = new List<Color>(){
                    Color.Accent, Color.Azure, Color.Bisque, Color.Gray, Color.Green, Color.Chocolate, Color.Black
                },
            };
            var dataBubble = new BubbleChartData(new List<IBubbleDataSet>() { dataSetBubble });


            var dataSetCandle = new CandleStickDataSet(entriesCandle, "Candle Stick DataSet 1")
            {
                DecreasingColor = Color.Red,
                IncreasingColor = Color.Green
            };
            var dataCandle = new CandleStickChartData(new List<ICandleStickDataSet>() { dataSetCandle });


            var dataSetLine = new LineDataSetXF(entrieLine, "Line DataSet 1")
            {
                CircleRadius = 10,
                CircleHoleRadius = 4f,
                CircleColors = new List<Color>(){
                    Color.Accent, Color.Azure, Color.Bisque, Color.Gray, Color.Green, Color.Chocolate, Color.Black
                },
                CircleHoleColor = Color.Green,
                Mode = LineDataSetMode.CUBIC_BEZIER
            };
            var dataLine = new LineChartData(new List<ILineDataSetXF>() { dataSetLine });


            var dataSetbar = new BarDataSet(entrieLine, "Bar DataSet 1")
            {
                Colors = new List<Color>(){
                    Color.Accent, Color.Azure, Color.Bisque, Color.Gray, Color.Green, Color.Chocolate, Color.Black
                },
            };
            var dataBar = new BarChartData(new List<IBarDataSet>() { dataSetbar });

            var combinData = new CombinedChartData(null);
            combinData.BubbleChartData = dataBubble;
            combinData.CandleStickChartData = dataCandle;
            combinData.LineChartData = dataLine;
            combinData.BarChartData = dataBar;
            chart.ChartData = combinData;
            chart.XAxis.AxisValueFormatter = new TextByIndexXAxisFormatter(labels);
        }
    }
}