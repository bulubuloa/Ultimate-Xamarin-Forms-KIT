using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models.BubbleChart;
using Xamarin.Forms;

namespace DemoXF
{
    public partial class BubbleChartPage : ContentPage
    {
        public BubbleChartPage()
        {
            InitializeComponent();

            var entries = new List<BubbleEntry>();
            entries.Add(new BubbleEntry(0, 0, 0f));
            entries.Add(new BubbleEntry(1, 50f, 3f));
            entries.Add(new BubbleEntry(2, 10f, 5f));
            entries.Add(new BubbleEntry(3, 30f, 1f));
            entries.Add(new BubbleEntry(4, 20f, 2f));
            entries.Add(new BubbleEntry(5, 15f, 4f));
            entries.Add(new BubbleEntry(6, 0, 0f));

            var labels = new List<string>();
            labels.Add("");
            labels.Add("col1");
            labels.Add("col2");
            labels.Add("col3");
            labels.Add("col4");
            labels.Add("col5");
            labels.Add("");

            var dataSet4 = new BubbleDataSet(entries, "Bubble DataSet")
            {
                DrawValue = false,
                DataColorScheme = new List<Color>(){
                    Color.Accent, Color.Azure, Color.Bisque, Color.Gray, Color.Green, Color.Chocolate, Color.Black
                }
            };
            var data4 = new BubbleChartData(new List<IBubbleDataSet>() { dataSet4 }, labels);

            var dataSet5 = new BubbleDataSet(entries, "Bubble DataSet")
            {
                DrawValue = false,
                DataColorScheme = new List<Color>(){
                    Color.GreenYellow
                }
            };
            var data5 = new BubbleChartData(new List<IBubbleDataSet>() { dataSet5 }, labels);

            bubbleChart.ChartData = data4;
            bubbleChart2.ChartData = data5;
        }
    }
}