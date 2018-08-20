using Xamarin.Forms;

namespace DemoXF
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            bttLine.Clicked += async (sender, e) => {
                await Navigation.PushAsync(new LineChartPage());
            };
            bttBar.Clicked += async (sender, e) => {
                await Navigation.PushAsync(new BarChartPage());
            };
            bttPie.Clicked += async (sender, e) => {
                await Navigation.PushAsync(new PieChartPage());
            };
            bttRadar.Clicked += async (sender, e) => {
                await Navigation.PushAsync(new RadarChartPage());
            };
            bttCandle.Clicked += async (sender, e) => {
                await Navigation.PushAsync(new CandleStickChartPage());
            };
            bttScatter.Clicked += async (sender, e) => 
            {
                await Navigation.PushAsync(new ScatterChartPage());
            };
            bttCombined.Clicked += async (sender, e) => 
            {
                await Navigation.PushAsync(new CombinedChartPage());
            };
            bttBuble.Clicked += async (sender, e) => 
            {
                await Navigation.PushAsync(new BubbleChartPage());
            };
            bttHorizontal.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new HorizontalBarCharPage());
            };
        }
    }
}