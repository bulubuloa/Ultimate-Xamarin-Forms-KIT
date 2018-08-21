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

        private string _FontFamily;
        public string FontFamily
        {
            get => _FontFamily;
            set
            {
                _FontFamily = value;
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

        private Color? _TextColor;
        public Color? TextColor
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