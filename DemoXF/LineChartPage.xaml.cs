using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models;
using UltimateXF.Widget.Charts.Models.LineChart;
using Xamarin.Forms;

namespace DemoXF
{
    public partial class LineChartPage : ContentPage
    {
        public LineChartPage()
        {
            InitializeComponent();

            var entries = new List<EntryChart>();
            var entries2 = new List<EntryChart>();
            var labels = new List<string>();

            var random = new Random();
            for (int i = 0; i < 8; i++)
            {
                entries.Add(new EntryChart(i, random.Next(20)));
                entries2.Add(new EntryChart(i, random.Next(20)));
                labels.Add("Entry" + i);
            }

            var dataSet4 = new LineDataSetXF(entries, "Line DataSet 1")
            {
                CircleRadius = 10,
                CircleHoleRadius = 4f,
                CircleColors =  new List<Color>(){
                    Color.Accent, Color.Azure, Color.Bisque, Color.Gray, Color.Green, Color.Chocolate, Color.Black
                },
                CircleHoleColor = Color.Green,
                Mode = LineDataSetMode.CUBIC_BEZIER
            };
            var dataSet5 = new LineDataSetXF(entries2, "Line DataSet 2")
            {
                Colors = new List<Color>{
                    Color.Green
                },
                CircleHoleColor = Color.Blue,
                CircleColors = new List<Color>{
                    Color.Blue
                },
                CircleRadius = 3,
                DrawValues = false
            };

            var data4 = new LineChartData(new List<ILineDataSetXF>() { dataSet4,dataSet5 }, labels);

            chart.ChartData = data4;
            chart.DescriptionChart.Text = "Test label chart description";
            chart.AxisLeft.DrawGridLines = false;
            chart.AxisLeft.DrawAxisLine = false;
            chart.AxisLeft.Enabled = false;
            chart.AxisRight.DrawAxisLine = false;
            chart.AxisRight.DrawGridLines = false;
            chart.AxisRight.Enabled = false;
            chart.XAxis.XAXISPosition = XAXISPosition.BOTTOM;
            chart.XAxis.DrawGridLines = false;
        }
    }
}