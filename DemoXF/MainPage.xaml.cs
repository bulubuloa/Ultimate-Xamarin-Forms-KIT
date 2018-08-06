using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models;
using UltimateXF.Widget.Charts.Models.BarChart;
using UltimateXF.Widget.Charts.Models.PieChart;
using Xamarin.Forms;

namespace DemoXF
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var entries = new List<EntryChart>();
            entries.Add(new EntryChart(0,5));
            entries.Add(new EntryChart(1,7));
            entries.Add(new EntryChart(2,10));
            entries.Add(new EntryChart(3,3));
            entries.Add(new EntryChart(4, 1));
            entries.Add(new EntryChart(5, 7));
            entries.Add(new EntryChart(6, 2));
            var dataSet = new BarDataSet(entries, "Line Chart")
            {
                DataColor = Color.Red,
                DrawValue = false,
            };

            var entries2 = new List<EntryChart>();
            entries2.Add(new EntryChart(0, 1));
            entries2.Add(new EntryChart(1, 4));
            entries2.Add(new EntryChart(2, 9));
            entries2.Add(new EntryChart(3, 6));
            entries2.Add(new EntryChart(4, 3));
            entries2.Add(new EntryChart(5, 1));
            entries2.Add(new EntryChart(6, 7));
            var dataSet2 = new BarDataSet(entries2, "Line Chart 2")
            {
                DataColor = Color.Blue,
            };

            var entries3 = new List<PieEntry>();
            entries3.Add(new PieEntry(10,"col1",Color.Accent));
            entries3.Add(new PieEntry(30, "col2",Color.AliceBlue));
            entries3.Add(new PieEntry(25, "col3",Color.AntiqueWhite));
            entries3.Add(new PieEntry(25, "col4",Color.Aqua));
            entries3.Add(new PieEntry(10, "col5",Color.Aquamarine));
            var dataSet3 = new PieDataSet(entries3, "Pie Chart 2");

            var data = new PieChartData(dataSet3, null)
            {
                ValueDisplaySize = 13,
                ValueDisplayColor = Color.Blue,
                TextDisplaySize = 10,
                TextDisplayColor = Color.Green
            };
            pieChart.ChartData = data;
            //lineChart.ChartData = data;
            //lineChart.XAxisLabels = new List<string>
            //{
            //    "Col1","Col2","Col3","Col4","Col5","Col6","Col7",
            //};
            //lineChart2.ChartData = data;
        }
    }
}