using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models;
using UltimateXF.Widget.Charts.Models.Component;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts
{
    public class SupportChartView : SupportView
    {
        public static readonly BindableProperty XAxisProperty = BindableProperty.Create("XAxis", typeof(XAxisConfig), typeof(SupportChartView), new XAxisConfig());
        public XAxisConfig XAxis
        {
            private get => (XAxisConfig)GetValue(XAxisProperty);
            set => SetValue(XAxisProperty, value);
        }

        public static readonly BindableProperty LeftAxisProperty = BindableProperty.Create("LeftAxis", typeof(YAxisConfig), typeof(SupportChartView), new YAxisConfig());
        public YAxisConfig LeftAxis
        {
            private get => (YAxisConfig)GetValue(LeftAxisProperty);
            set => SetValue(LeftAxisProperty, value);
        }

        public static readonly BindableProperty RightAxisProperty = BindableProperty.Create("RightAxis", typeof(YAxisConfig), typeof(SupportChartView), new YAxisConfig());
        public YAxisConfig RightAxis
        {
            private get => (YAxisConfig)GetValue(XAxisProperty);
            set => SetValue(XAxisProperty, value);
        }

        public static readonly BindableProperty IsShowXAxisProperty = BindableProperty.Create("IsShowXAxis", typeof(bool), typeof(SupportChartView), true);
        public bool IsShowXAxis
        {
            get => (bool)GetValue(IsShowXAxisProperty);
            set => SetValue(IsShowXAxisProperty, value);
        }

        public static readonly BindableProperty IsShowLeftAxisProperty = BindableProperty.Create("IsShowLeftAxis", typeof(bool), typeof(SupportChartView), true);
        public bool IsShowLeftAxis
        {
            get => (bool)GetValue(IsShowLeftAxisProperty);
            set => SetValue(IsShowLeftAxisProperty, value);
        }

        public static readonly BindableProperty IsShowRightAxisProperty = BindableProperty.Create("IsShowRightAxis", typeof(bool), typeof(SupportChartView), true);
        public bool IsShowRightAxis
        {
            get => (bool)GetValue(IsShowRightAxisProperty);
            set => SetValue(IsShowRightAxisProperty, value);
        }

        public static readonly BindableProperty IsShowLeftAxisLineProperty = BindableProperty.Create("IsShowLeftAxisLine", typeof(bool), typeof(SupportChartView), true);
        public bool IsShowLeftAxisLine
        {
            get => (bool)GetValue(IsShowLeftAxisLineProperty);
            set => SetValue(IsShowLeftAxisLineProperty, value);
        }

        public static readonly BindableProperty IsShowRightAxisLineProperty = BindableProperty.Create("IsShowRightAxisLine", typeof(bool), typeof(SupportChartView), true);
        public bool IsShowRightAxisLine
        {
            get => (bool)GetValue(IsShowRightAxisLineProperty);
            set => SetValue(IsShowRightAxisLineProperty, value);
        }

        public static readonly BindableProperty IsShowXAxisLineProperty = BindableProperty.Create("IsShowXAxisLine", typeof(bool), typeof(SupportChartView), true);
        public bool IsShowXAxisLine
        {
            get => (bool)GetValue(IsShowXAxisLineProperty);
            set => SetValue(IsShowXAxisLineProperty, value);
        }

        public static readonly BindableProperty DescriptionProperty = BindableProperty.Create("DescriptionProperty", typeof(string), typeof(SupportChartView), "");
        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }

        public static readonly BindableProperty IsShowLeftAxisValueProperty = BindableProperty.Create("IsShowLeftAxisValue", typeof(bool), typeof(SupportChartView), true);
        public bool IsShowLeftAxisValue
        {
            get => (bool)GetValue(IsShowLeftAxisValueProperty);
            set => SetValue(IsShowLeftAxisValueProperty, value);
        }

        public static readonly BindableProperty IsShowRightAxisValueProperty = BindableProperty.Create("IsShowRightAxisValue", typeof(bool), typeof(SupportChartView), true);
        public bool IsShowRightAxisValue
        {
            get => (bool)GetValue(IsShowRightAxisValueProperty);
            set => SetValue(IsShowRightAxisValueProperty, value);
        }

        public static readonly BindableProperty IsShowXAxisValueProperty = BindableProperty.Create("IsShowXAxisValue", typeof(bool), typeof(SupportChartView), true);
        public bool IsShowXAxisValue
        {
            get => (bool)GetValue(IsShowXAxisValueProperty);
            set => SetValue(IsShowXAxisValueProperty, value);
        }

        public static readonly BindableProperty XAxisPositionProperty = BindableProperty.Create("XAxisPosition", typeof(XAXISPosition), typeof(SupportChartView), XAXISPosition.TOP);
        public XAXISPosition XAxisPosition
        {
            get => (XAXISPosition)GetValue(XAxisPositionProperty);
            set => SetValue(XAxisPositionProperty, value);
        }

        public static readonly BindableProperty IsDragEnabledProperty = BindableProperty.Create("IsDragEnabled", typeof(bool), typeof(SupportChartView), true);
        public bool IsDragEnabled
        {
            get => (bool)GetValue(IsDragEnabledProperty);
            set => SetValue(IsDragEnabledProperty, value);
        }

        public static readonly BindableProperty IsTouchEnabledProperty = BindableProperty.Create("IsTouchEnabled", typeof(bool), typeof(SupportChartView), true);
        public bool IsTouchEnabled
        {
            get => (bool)GetValue(IsTouchEnabledProperty);
            set => SetValue(IsTouchEnabledProperty, value);
        }

        public static readonly BindableProperty IsDoubleTapToZoomEnabledProperty = BindableProperty.Create("IsDoubleTapToZoomEnabled", typeof(bool), typeof(SupportChartView), true);
        public bool IsDoubleTapToZoomEnabled
        {
            get => (bool)GetValue(IsDoubleTapToZoomEnabledProperty);
            set => SetValue(IsDoubleTapToZoomEnabledProperty, value);
        }

        public static readonly BindableProperty IsPinchZoomEnabledProperty = BindableProperty.Create("IsPinchZoomEnabled", typeof(bool), typeof(SupportChartView), true);
        public bool IsPinchZoomEnabled
        {
            get => (bool)GetValue(IsPinchZoomEnabledProperty);
            set => SetValue(IsPinchZoomEnabledProperty, value);
        }

        public static readonly BindableProperty IsScaleXEnabledProperty = BindableProperty.Create("IsScaleXEnabled", typeof(bool), typeof(SupportChartView), true);
        public bool IsScaleXEnabled
        {
            get => (bool)GetValue(IsScaleXEnabledProperty);
            set => SetValue(IsScaleXEnabledProperty, value);
        }

        public static readonly BindableProperty IsScaleYEnabledProperty = BindableProperty.Create("IsScaleYEnabled", typeof(bool), typeof(SupportChartView), true);
        public bool IsScaleYEnabled
        {
            get => (bool)GetValue(IsScaleYEnabledProperty);
            set => SetValue(IsScaleYEnabledProperty, value);
        }

        //Color templates


        public SupportChartView()
        {
        }
    }
}
