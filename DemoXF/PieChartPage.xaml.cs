using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models.PieChart;
using Xamarin.Forms;

namespace DemoXF
{
    public partial class PieChartPage : ContentPage
    {
        public PieChartPage()
        {
            InitializeComponent();

            var entries = new List<PieEntry>();
            entries.Add(new PieEntry(10,"Col1"));
            entries.Add(new PieEntry(15,"Col2"));
            entries.Add(new PieEntry(15,"Col3"));
            entries.Add(new PieEntry(20,"Col4"));
            entries.Add(new PieEntry(35,"Col5"));
            entries.Add(new PieEntry(5,"Col6"));


            var labels = new List<string>();
            labels.Add("col1");
            labels.Add("col2");
            labels.Add("col3");
            labels.Add("col4");
            labels.Add("col5");
            labels.Add("col6");

            var dataSet4 = new PieDataSet(entries, "Pie DataSet")
            {
                DrawValue = true,
                DataColorScheme = new List<Color>(){
                    Color.Accent, Color.Azure, Color.Bisque, Color.Gray, Color.Green, Color.Chocolate
                }
            };
            var data4 = new PieChartData(dataSet4, labels)
            {
                ValueDisplaySize = 13,
                ValueDisplayColor = Color.Blue,
                TextDisplaySize = 10,
                TextDisplayColor = Color.Green
            };

            var dataSet5 = new PieDataSet(entries, "Pie DataSet")
            {
                DrawValue = true,
                DataColorScheme = new List<Color>(){
                    Color.GreenYellow,Color.Beige,Color.DarkRed,Color.BlanchedAlmond,Color.Brown,Color.Cyan
                },
            };
            var data5 = new PieChartData(dataSet5, labels);

            pieChart.ChartData = data4;
            pieChart2.ChartData = data5;
        }
    }
}