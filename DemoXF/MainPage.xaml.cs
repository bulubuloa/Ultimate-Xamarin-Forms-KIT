using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateXF.Widget.Charts.Models;
using Xamarin.Forms;

namespace DemoXF
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var entries = new List<UltimateXF.Widget.Charts.Models.Entry>();
            entries.Add(new UltimateXF.Widget.Charts.Models.Entry(0,5));
            entries.Add(new UltimateXF.Widget.Charts.Models.Entry(1,7));
            entries.Add(new UltimateXF.Widget.Charts.Models.Entry(2,10));
            entries.Add(new UltimateXF.Widget.Charts.Models.Entry(3,3));
            var dataSet = new BaseDataSet<UltimateXF.Widget.Charts.Models.Entry>(entries,"Line Chart");
            var data = new BaseData<UltimateXF.Widget.Charts.Models.Entry>(new List<IBaseDataSet<UltimateXF.Widget.Charts.Models.Entry>>{dataSet} ,new List<string>());
            lineChart.ChartData = data;
        }
    }
}
