using System;
using Xamarin.Forms;

namespace UltimateXF.Widget.Charts.Models.Component
{
    public abstract class ConfigBase : BindableObject
    {
        private bool? _Enabled;
        public bool? Enabled
        {
            get => _Enabled;
            set
            {
                _Enabled = value;
                OnPropertyChanged();
            }
        }

        private float? _XOffset;
        public float? XOffset
        {
            get => _XOffset;
            set
            {
                _XOffset = value;
                OnPropertyChanged();
            }
        }

        private float? _YOffset;
        public float? YOffset
        {
            get => _YOffset;
            set
            {
                _YOffset = value;
                OnPropertyChanged();
            }
        }

        private Font? _Typeface;
        public Font? Typeface
        {
            get => _Typeface;
            set
            {
                _Typeface = value;
                OnPropertyChanged();
            }
        }

        private float? _TextSize;
        public float? TextSize
        {
            get => _TextSize;
            set
            {
                _TextSize = value;
                OnPropertyChanged();
            }
        }

        private int? _TextColor;
        public int? TextColor
        {
            get => _TextColor;
            set
            {
                _TextColor = value;
                OnPropertyChanged();
            }
        }

        public ConfigBase()
        {

        }
    }
}