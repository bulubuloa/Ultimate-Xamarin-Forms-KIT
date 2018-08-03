using System;
using UltimateXF.Widget.Charts.Models;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts
{
    public class SupportLineChart : SupportChartView
    {
        public static readonly BindableProperty ChartDataProperty = BindableProperty.Create("ChartData", typeof(IBaseData<EntryChart>), typeof(SupportLineChart), null);
        public IBaseData<EntryChart> ChartData
        {
            get => (IBaseData<EntryChart>)GetValue(ChartDataProperty);
            set => SetValue(ChartDataProperty, value);
        }

        public static readonly BindableProperty IsShowXAxisProperty = BindableProperty.Create("IsShowXAxis", typeof(bool), typeof(SupportLineChart), true);
        public bool IsShowXAxis
        {
            get => (bool)GetValue(IsShowXAxisProperty);
            set => SetValue(IsShowXAxisProperty, value);
        }

        public static readonly BindableProperty IsShowLeftAxisProperty = BindableProperty.Create("IsShowLeftAxis", typeof(bool), typeof(SupportLineChart), true);
        public bool IsShowLeftAxis
        {
            get => (bool)GetValue(IsShowLeftAxisProperty);
            set => SetValue(IsShowLeftAxisProperty, value);
        }

        public static readonly BindableProperty IsShowRightAxisProperty = BindableProperty.Create("IsShowRightAxis", typeof(bool), typeof(SupportLineChart), true);
        public bool IsShowRightAxis
        {
            get => (bool)GetValue(IsShowRightAxisProperty);
            set => SetValue(IsShowRightAxisProperty, value);
        }

        public static readonly BindableProperty IsShowLeftAxisLineProperty = BindableProperty.Create("IsShowLeftAxisLine", typeof(bool), typeof(SupportLineChart), true);
        public bool IsShowLeftAxisLine
        {
            get => (bool)GetValue(IsShowLeftAxisLineProperty);
            set => SetValue(IsShowLeftAxisLineProperty, value);
        }

        public static readonly BindableProperty IsShowRightAxisLineProperty = BindableProperty.Create("IsShowRightAxisLine", typeof(bool), typeof(SupportLineChart), true);
        public bool IsShowRightAxisLine
        {
            get => (bool)GetValue(IsShowRightAxisLineProperty);
            set => SetValue(IsShowRightAxisLineProperty, value);
        }

        public static readonly BindableProperty IsShowXAxisLineProperty = BindableProperty.Create("IsShowXAxisLine", typeof(bool), typeof(SupportLineChart), true);
        public bool IsShowXAxisLine
        {
            get => (bool)GetValue(IsShowXAxisLineProperty);
            set => SetValue(IsShowXAxisLineProperty, value);
        }

        public static readonly BindableProperty DescriptionProperty = BindableProperty.Create("DescriptionProperty", typeof(string), typeof(SupportLineChart), "");
        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }

        public static readonly BindableProperty IsShowLeftAxisValueProperty = BindableProperty.Create("IsShowLeftAxisValue", typeof(bool), typeof(SupportLineChart), true);
        public bool IsShowLeftAxisValue
        {
            get => (bool)GetValue(IsShowLeftAxisValueProperty);
            set => SetValue(IsShowLeftAxisValueProperty, value);
        }

        public static readonly BindableProperty IsShowRightAxisValueProperty = BindableProperty.Create("IsShowRightAxisValue", typeof(bool), typeof(SupportLineChart), true);
        public bool IsShowRightAxisValue
        {
            get => (bool)GetValue(IsShowRightAxisValueProperty);
            set => SetValue(IsShowRightAxisValueProperty, value);
        }

        public static readonly BindableProperty IsShowXAxisValueProperty = BindableProperty.Create("IsShowXAxisValue", typeof(bool), typeof(SupportLineChart), true);
        public bool IsShowXAxisValue
        {
            get => (bool)GetValue(IsShowXAxisValueProperty);
            set => SetValue(IsShowXAxisValueProperty, value);
        }

        public static readonly BindableProperty XAxisPositionProperty = BindableProperty.Create("XAxisPosition", typeof(XAXISPosition), typeof(SupportLineChart), XAXISPosition.TOP);
        public XAXISPosition XAxisPosition
        {
            get => (XAXISPosition)GetValue(XAxisPositionProperty);
            set => SetValue(XAxisPositionProperty, value);
        }

        public static readonly BindableProperty IsDragEnabledProperty = BindableProperty.Create("IsDragEnabled", typeof(bool), typeof(SupportLineChart), true);
        public bool IsDragEnabled
        {
            get => (bool)GetValue(IsDragEnabledProperty);
            set => SetValue(IsDragEnabledProperty, value);
        }

        public static readonly BindableProperty IsTouchEnabledProperty = BindableProperty.Create("IsTouchEnabled", typeof(bool), typeof(SupportLineChart), true);
        public bool IsTouchEnabled
        {
            get => (bool)GetValue(IsTouchEnabledProperty);
            set => SetValue(IsTouchEnabledProperty, value);
        }

        public static readonly BindableProperty IsDoubleTapToZoomEnabledProperty = BindableProperty.Create("IsDoubleTapToZoomEnabled", typeof(bool), typeof(SupportLineChart), true);
        public bool IsDoubleTapToZoomEnabled
        {
            get => (bool)GetValue(IsDoubleTapToZoomEnabledProperty);
            set => SetValue(IsDoubleTapToZoomEnabledProperty, value);
        }

        public static readonly BindableProperty IsPinchZoomEnabledProperty = BindableProperty.Create("IsPinchZoomEnabled", typeof(bool), typeof(SupportLineChart), true);
        public bool IsPinchZoomEnabled
        {
            get => (bool)GetValue(IsPinchZoomEnabledProperty);
            set => SetValue(IsPinchZoomEnabledProperty, value);
        }

        public static readonly BindableProperty IsScaleXEnabledProperty = BindableProperty.Create("IsScaleXEnabled", typeof(bool), typeof(SupportLineChart), true);
        public bool IsScaleXEnabled
        {
            get => (bool)GetValue(IsScaleXEnabledProperty);
            set => SetValue(IsScaleXEnabledProperty, value);
        }

        public static readonly BindableProperty IsScaleYEnabledProperty = BindableProperty.Create("IsScaleYEnabled", typeof(bool), typeof(SupportLineChart), true);
        public bool IsScaleYEnabled
        {
            get => (bool)GetValue(IsScaleYEnabledProperty);
            set => SetValue(IsScaleYEnabledProperty, value);
        }

        public SupportLineChart()
        {
            
        }
    }
}