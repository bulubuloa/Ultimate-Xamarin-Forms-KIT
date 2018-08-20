using System;
namespace UltimateXF.Widget.Charts.Models.Component
{
    public class XAxisConfig : AxisConfigBase
    {
        private int? _LabelWidth;
        public int? LabelWidth
        {
            get => _LabelWidth;
            set
            {
                _LabelWidth = value;
                OnPropertyChanged();
            }
        }

        private int? _LabelHeight;
        public int? LabelHeight
        {
            get => _LabelHeight;
            set
            {
                _LabelHeight = value;
                OnPropertyChanged();
            }
        }

        private XAXISPosition? _XAXISPosition;
        public XAXISPosition? XAXISPosition
        {
            get => _XAXISPosition;
            set
            {
                _XAXISPosition = value;
                OnPropertyChanged();
            }
        }

        private float? _LabelRotationAngle;
        public float? LabelRotationAngle
        {
            get => _LabelRotationAngle;
            set
            {
                _LabelRotationAngle = value;
                OnPropertyChanged();
            }
        }

        private bool? _AvoidFirstLastClipping;
        public bool? AvoidFirstLastClipping
        {
            get => _AvoidFirstLastClipping;
            set
            {
                _AvoidFirstLastClipping = value;
                OnPropertyChanged();
            }
        }

        public XAxisConfig()
        {
        }
    }
}