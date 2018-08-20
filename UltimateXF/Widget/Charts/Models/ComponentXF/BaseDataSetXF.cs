using System;
using System.Collections.Generic;
using UltimateXF.Widget.Charts.Models.ComponentXF;
using UltimateXF.Widget.Charts.Models.Formatters;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.Component
{
    public class GradientColor
    {
        public Color StartColor;
        public Color EndColor;

        public GradientColor(Color startColor, Color endColor)
        {
            this.StartColor = startColor;
            this.EndColor = endColor;
        }
    }

    public abstract class BaseDataSetXF<TEntry> : BindableObject,IBaseDataSetXF<TEntry> where TEntry : BaseEntry
    {
        /*
         * protected Typeface mValueTypeface;
         * protected MPPointF mIconsOffset = new MPPointF();
         * 
         */
        private List<TEntry> _Values;
        public List<TEntry> Values
        {
            get => _Values;
            set
            {
                _Values = value;
                OnPropertyChanged();
            }
        }

        private List<Color> _Colors;
        public List<Color> Colors
        {
            get => _Colors;
            set
            {
                _Colors = value;
                OnPropertyChanged();
            }
        }

        private List<Color> _ValueColors;
        public List<Color> ValueColors
        {
            get => _ValueColors;
            set
            {
                _ValueColors = value;
                OnPropertyChanged();
            }
        }

        private GradientColor _GradientColor;
        public GradientColor GradientColor
        {
            get => _GradientColor;
            set
            {
                _GradientColor = value;
                OnPropertyChanged();
            }
        }

        private List<GradientColor> _GradientColors;
        public List<GradientColor> GradientColors
        {
            get => _GradientColors;
            set
            {
                _GradientColors = value;
                OnPropertyChanged();
            }
        }

        private string _Label;
        public string Label
        {
            get => _Label;
            set
            {
                _Label = value;
                OnPropertyChanged();
            }
        }

        private bool? _HighlightEnabled;
        public bool? HighlightEnabled
        {
            get => _HighlightEnabled;
            set
            {
                _HighlightEnabled = value;
                OnPropertyChanged();
            }
        }

        private bool? _Visible;
        public bool? Visible
        {
            get => _Visible;
            set
            {
                _Visible = value;
                OnPropertyChanged();
            }
        }

        private float? _ValueTextSize;
        public float? ValueTextSize
        {
            get => _ValueTextSize;
            set
            {
                _ValueTextSize = value;
                OnPropertyChanged();
            }
        }

        private bool? _DrawIcons;
        public bool? DrawIcons
        {
            get => _DrawIcons;
            set
            {
                _DrawIcons = value;
                OnPropertyChanged();
            }
        }

        private bool? _DrawValues;
        public bool? DrawValues
        {
            get => _DrawValues;
            set
            {
                _DrawValues = value;
                OnPropertyChanged();
            }
        }

        private IValueFormatterXF _ValueFormatter;
        public IValueFormatterXF ValueFormatter
        {
            get => ValueFormatter;
            set
            {
                ValueFormatter = value;
                OnPropertyChanged();
            }
        }

        public BaseDataSetXF(List<TEntry> entries, string _label)
        {
            this.Values = entries;
            this.Label = _label;
        }

        public List<TEntry> IF_GetValues()
        {
            return Values;
        }

        public List<Color> IF_GetColors()
        {
            return Colors;
        }

        public List<Color> IF_GetValueColors()
        {
            return ValueColors;
        }

        public GradientColor IF_GetGradientColor()
        {
            return GradientColor;
        }

        public List<GradientColor> IF_GetGradientColors()
        {
            return GradientColors;
        }

        public string IF_GetLabel()
        {
            return Label;
        }

        public bool? IF_GetHighlightEnabled()
        {
            return HighlightEnabled;
        }

        public bool? IF_GetVisible()
        {
            return Visible;
        }

        public float? IF_GetValueTextSize()
        {
            return ValueTextSize;
        }

        public bool? IF_GetDrawIcons()
        {
            return DrawIcons;
        }

        public bool? IF_GetDrawValues()
        {
            return DrawValues;
        }

        public IValueFormatterXF IF_GetValueFormatter()
        {
            return ValueFormatter;
        }
    }
}