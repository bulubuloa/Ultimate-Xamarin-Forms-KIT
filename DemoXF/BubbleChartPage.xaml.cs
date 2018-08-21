using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models.BubbleChart;
using UltimateXF.Widget.Charts.Models.Formatters;
using Xamarin.Forms;

namespace DemoXF
{
    public partial class BubbleChartPage : ContentPage
    {
        public BubbleChartPage()
        {
            InitializeComponent();

            var entries = new List<BubbleEntry>();
            var entries2 = new List<BubbleEntry>();
            var labels = new List<string>();

            Random random = new Random();
            for (int i = 0; i < 8; i++)
            {
                entries.Add(new BubbleEntry(i, random.Next(8),random.Next(20)));
                entries2.Add(new BubbleEntry(i,random.Next(8), random.Next(20)));
                labels.Add("Entry" + i);
            }

            var dataSet4 = new BubbleDataSet(entries, "Bubble DataSet 1")
            {
                Colors = new List<Color>(){
                    Color.Accent, Color.Azure, Color.Bisque, Color.Gray, Color.Green, Color.Chocolate, Color.Black
                },
            };
            var dataSet5 = new BubbleDataSet(entries2, "Bubble DataSet 2")
            {
                Colors = new List<Color>{
                    Color.Green
                },
            };

            var data4 = new BubbleChartData(new List<IBubbleDataSet>() { dataSet4 });

            chart.ChartData = data4;
            chart.DescriptionChart.Text = "Test label chart description";

            chart.AxisLeft.DrawGridLines = false;
            chart.AxisLeft.DrawAxisLine = true;
            chart.AxisLeft.Enabled = true;

            chart.AxisRight.DrawAxisLine = false;
            chart.AxisRight.DrawGridLines = false;
            chart.AxisRight.Enabled = false;

           chart.XAxis.DrawGridLines = false;
            chart.XAxis.AxisValueFormatter = new TextByIndexXAxisFormatter(labels);
        }
    }
}