using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace UltimateXF.Widget
{
    public class SupportEntry : Entry
    {
        public SupportEntry()
        {
            Focused += OnFocused;
            Unfocused += OnUnfocused;
        }

        private Color _CurrentCornerColor;
        public Color CurrentCornerColor
        {
            get => _CurrentCornerColor;
            private set
            {
                _CurrentCornerColor = value;
                OnPropertyChanged(nameof(CurrentCornerColor));
            }
        }

        private void OnFocused(object sender, FocusEventArgs e)
        {
            IsValid = true;
            CurrentCornerColor = FocusEntryCornerColor != Color.Default ? FocusEntryCornerColor : GetNormalStateLineColor();
        }

        private void OnUnfocused(object sender, FocusEventArgs e)
        {
            ResetCornerColor();
        }

        private Color GetNormalStateLineColor()
        {
            return EntryCornerColor != Color.Default ? EntryCornerColor : TextColor;
        }

        private void ResetCornerColor()
        {
            CurrentCornerColor = GetNormalStateLineColor();
            IsValid = true;
        }

        private void CheckValidity()
        {
            if (!IsValid)
            {
                CurrentCornerColor = InvaidEntryCornerColor;
            }
        }

        public static readonly BindableProperty IsValidProperty = BindableProperty.Create("IsValid", typeof(bool), typeof(SupportEntry), true);
        public bool IsValid
        {
            get => (bool)GetValue(IsValidProperty);
            set => SetValue(IsValidProperty, value);
        }

        public static readonly BindableProperty DrawableInsideProperty = BindableProperty.Create("DrawableInside", typeof(string), typeof(SupportEntry), string.Empty);
        public string DrawableInside
        {
            get => (string)GetValue(DrawableInsideProperty);
            set => SetValue(DrawableInsideProperty, value);
        }

        public static readonly BindableProperty DrawableInsideAligmentProperty = BindableProperty.Create("DrawableInsideAligment", typeof(SupportEntryDrawableInsideAligment), typeof(SupportEntry), SupportEntryDrawableInsideAligment.Left);
        public SupportEntryDrawableInsideAligment DrawableInsideAligment
        {
            get => (SupportEntryDrawableInsideAligment)GetValue(DrawableInsideAligmentProperty);
            set => SetValue(DrawableInsideAligmentProperty, value);
        }

        public static readonly BindableProperty VerticalTextAligmentProperty = BindableProperty.Create("VerticalTextAligment", typeof(SupportEntryVerticalTextAligment), typeof(SupportEntry), SupportEntryVerticalTextAligment.Top);
        public SupportEntryVerticalTextAligment VerticalTextAligment
        {
            get => (SupportEntryVerticalTextAligment)GetValue(VerticalTextAligmentProperty);
            set => SetValue(VerticalTextAligmentProperty, value);
        }

        public static readonly BindableProperty PaddingInsideProperty = BindableProperty.Create("PaddingInside", typeof(double), typeof(SupportEntry), 0d);
        public double PaddingInside
        {
            get => (double)GetValue(PaddingInsideProperty);
            set => SetValue(PaddingInsideProperty, value);
        }

        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create("CornerRadius", typeof(double), typeof(SupportEntry), 0d);
        public double CornerRadius
        {
            get => (double)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static readonly BindableProperty CornerWidthProperty = BindableProperty.Create("CornerWidth", typeof(double), typeof(SupportEntry), 0d);
        public double CornerWidth
        {
            get => (double)GetValue(CornerWidthProperty);
            set => SetValue(CornerWidthProperty, value);
        }

        public static readonly BindableProperty EntryCornerProperty = BindableProperty.Create("EntryCorner", typeof(SupportEntryCorner), typeof(SupportEntry), SupportEntryCorner.None);
        public SupportEntryCorner EntryCorner
        {
            get => (SupportEntryCorner)GetValue(EntryCornerProperty);
            set => SetValue(EntryCornerProperty, value);
        }

        public static readonly BindableProperty FocusEntryCornerColorProperty = BindableProperty.Create("FocusEntryCornerColor", typeof(Color), typeof(SupportEntry), Color.Default);
        public Color FocusEntryCornerColor
        {
            get => (Color)GetValue(FocusEntryCornerColorProperty);
            set => SetValue(FocusEntryCornerColorProperty, value);
        }

        public static readonly BindableProperty EntryCornerColorProperty = BindableProperty.Create("EntryCornerColor", typeof(Color), typeof(SupportEntry), Color.Default);
        public Color EntryCornerColor
        {
            get => (Color)GetValue(EntryCornerColorProperty);
            set => SetValue(EntryCornerColorProperty, value);
        }

        public static readonly BindableProperty InvaidEntryCornerColorProperty = BindableProperty.Create("InvaidEntryCornerColor", typeof(Color), typeof(SupportEntry), Color.Default);
        public Color InvaidEntryCornerColor
        {
            get => (Color)GetValue(InvaidEntryCornerColorProperty);
            set => SetValue(InvaidEntryCornerColorProperty, value);
        }

        public static readonly BindableProperty BackgroundColorInsideProperty = BindableProperty.Create("BackgroundColorInside", typeof(Color), typeof(SupportEntry), Color.Default);
        public Color BackgroundColorInside
        {
            get => (Color)GetValue(BackgroundColorInsideProperty);
            set => SetValue(BackgroundColorInsideProperty, value);
        }

        public static readonly BindableProperty CursorPositionProperty = BindableProperty.Create("CursorPosition", typeof(int), typeof(SupportEntry), 0);
        public int CursorPosition
        {
            get => (int)GetValue(CursorPositionProperty);
            set => SetValue(CursorPositionProperty, value);
        }

        public static readonly BindableProperty ReturnKeyProperty = BindableProperty.Create(nameof(ReturnKey), typeof(SupportEntryReturnType), typeof(SupportEntry), SupportEntryReturnType.Done, BindingMode.OneWay);
        public SupportEntryReturnType ReturnKey
        {
            get => (SupportEntryReturnType)GetValue(ReturnTypeProperty);
            set => SetValue(ReturnTypeProperty, value);
        }

        public new event EventHandler Completed;
        public void InvokeCompleted()
        {
            if (this.Completed != null)
                this.Completed.Invoke(this, null);
            CommandDone?.Execute(CommandDoneParameter);
        }

        public static readonly BindableProperty CommandDoneProperty = BindableProperty.Create("CommandDone", typeof(ICommand), typeof(SupportEntry), null, propertyChanged: (bo, o, n) => ((SupportEntry)bo).OnCommandChanged());
        public static readonly BindableProperty CommandDoneParameterProperty = BindableProperty.Create("CommandDoneParameter", typeof(object), typeof(SupportEntry), null, propertyChanged: (bindable, oldvalue, newvalue) => ((SupportEntry)bindable).CommandCanExecuteChanged(bindable, EventArgs.Empty));

        public ICommand CommandDone
        {
            get { return (ICommand)GetValue(CommandDoneProperty); }
            set { SetValue(CommandDoneProperty, value); }
        }

        public object CommandDoneParameter
        {
            get { return GetValue(CommandDoneParameterProperty); }
            set { SetValue(CommandDoneParameterProperty, value); }
        }

        void OnCommandChanged()
        {
            if (CommandDone != null)
            {
                CommandDone.CanExecuteChanged += CommandCanExecuteChanged;
                CommandCanExecuteChanged(this, EventArgs.Empty);
            }
            else
                IsEnabledCore = true;
        }

        void CommandCanExecuteChanged(object sender, EventArgs eventArgs)
        {
            ICommand cmd = CommandDone;
            if (cmd != null)
                IsEnabledCore = cmd.CanExecute(CommandDoneParameter);
        }

        bool IsEnabledCore
        {
            set { SetValueCore(IsEnabledProperty, value); }
        }


        public static readonly BindableProperty NextViewProperty = BindableProperty.Create("NextView", typeof(View), typeof(SupportEntry));
        public View NextView
        {
            get => (View)GetValue(NextViewProperty);
            set => SetValue(NextViewProperty, value);
        }

        public void OnNext()
        {
            NextView?.Focus();
        }

        public void RunReturnAction()
        {
            var type = ReturnKey;
            switch (type)
            {
                case SupportEntryReturnType.Go:
                    InvokeCompleted();
                    break;
                case SupportEntryReturnType.Next:
                    OnNext();
                    break;
                case SupportEntryReturnType.Send:
                    InvokeCompleted();
                    break;
                case SupportEntryReturnType.Search:
                    InvokeCompleted();
                    break;
                case SupportEntryReturnType.Done:
                    InvokeCompleted();
                    break;
                default:
                    InvokeCompleted();
                    break;
            }
        }

        protected override void OnPropertyChanging([CallerMemberName] string propertyName = null)
        {
            if (propertyName == CommandDoneProperty.PropertyName)
            {
                ICommand cmd = CommandDone;
                if (cmd != null) cmd.CanExecuteChanged -= CommandCanExecuteChanged;
            }

            base.OnPropertyChanging(propertyName);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == IsValidProperty.PropertyName)
            {
                CheckValidity();
            }
        }
    }
}