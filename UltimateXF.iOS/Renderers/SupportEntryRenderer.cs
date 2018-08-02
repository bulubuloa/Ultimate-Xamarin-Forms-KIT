using System;
using System.ComponentModel;
using System.Drawing;
using CoreGraphics;
using UIKit;
using UltimateXF.iOS.Renderers;
using UltimateXF.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SupportEntry), typeof(SupportEntryRenderer))]
namespace UltimateXF.iOS.Renderers
{
    public class SupportEntryRenderer : EntryRenderer
    {
        private SupportEntry supportEntry;
        private nfloat WidthOfContentLeft = 30, HeightOfContentLeft = 30;
        private nfloat WidthOfImageLeft = 20, HeightOfImageLeft = 20;

        public SupportEntryRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                if (Element is SupportEntry)
                {
                    supportEntry = Element as SupportEntry;

                    Control.ClipsToBounds = true;
                    if (supportEntry.CornerRadius > 0)
                    {
                        //
                    }
                    else
                    {
                        Control.BorderStyle = UITextBorderStyle.None;
                    }
                    Control.Layer.CornerRadius = (float)supportEntry.CornerRadius;
                    Control.Layer.BorderWidth = (float)supportEntry.CornerWidth;
                    Control.Layer.BorderColor = supportEntry.EntryCornerColor.ToCGColor();

                    InitilizeDrawableInsideView(supportEntry.DrawableInside, supportEntry.DrawableInsideAligment);
                    InitlizeReturnKey();
                    InitlizePaddingInside();

                    Control.ShouldReturn += (UITextField tf) =>
                    {
                        supportEntry.RunReturnAction();
                        return true;
                    };
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(nameof(SupportEntry.CurrentCornerColor)))
            {
                if (supportEntry != null)
                {
                    Control.Layer.BorderColor = supportEntry.CurrentCornerColor.ToCGColor();
                }
            }
            else if (e.PropertyName.Equals(nameof(SupportEntry.CursorPosition)))
            {
                if (supportEntry != null)
                {
                    var positionToSet = Control.GetPosition(Control.BeginningOfDocument, supportEntry.CursorPosition);
                    Control.SelectedTextRange = Control.GetTextRange(positionToSet, positionToSet);
                }
            }
        }

        private void CreateToolbarIfNumberKeyboard()
        {
            if (Control.KeyboardType == UIKeyboardType.DecimalPad && supportEntry.ReturnKey == SupportEntryReturnType.Next)
            {
                UIToolbar toolbar = new UIToolbar()
                {
                    Frame = new RectangleF(0.0f, 0.0f, 320, 44.0f),
                    TintColor = UIColor.DarkGray,
                    Translucent = false,
                    Items = new UIBarButtonItem[]
                    {
                        new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
                        new UIBarButtonItem("Next", UIBarButtonItemStyle.Bordered, delegate
                            {
                                supportEntry.RunReturnAction();
                            })
                    }
                };
                this.Control.InputAccessoryView = toolbar;
            }
        }

        private void InitlizeReturnKey()
        {
            CreateToolbarIfNumberKeyboard();
            var type = supportEntry.ReturnKey;

            switch (type)
            {
                case SupportEntryReturnType.Go:
                    Control.ReturnKeyType = UIReturnKeyType.Go;
                    break;
                case SupportEntryReturnType.Next:
                    Control.ReturnKeyType = UIReturnKeyType.Next;
                    break;
                case SupportEntryReturnType.Send:
                    Control.ReturnKeyType = UIReturnKeyType.Send;
                    break;
                case SupportEntryReturnType.Search:
                    Control.ReturnKeyType = UIReturnKeyType.Search;
                    break;
                case SupportEntryReturnType.Done:
                    Control.ReturnKeyType = UIReturnKeyType.Done;
                    break;
                default:
                    Control.ReturnKeyType = UIReturnKeyType.Default;
                    break;
            }
        }

        private void InitlizePaddingInside()
        {
            if (supportEntry.PaddingInside > 0)
            {
                Control.LeftView = new UIView(new CGRect(0, 0, supportEntry.PaddingInside, 0));
                Control.LeftViewMode = UITextFieldViewMode.Always;
                Control.RightView = new UIView(new CGRect(0, 0, supportEntry.PaddingInside, 0));
                Control.RightViewMode = UITextFieldViewMode.Always;
            }
        }

        private void InitilizeDrawableInsideView(string icon, SupportEntryDrawableInsideAligment aligment)
        {
            try
            {
                if (string.IsNullOrEmpty(icon))
                {
                    return;
                }
                else
                {
                    var ImageInside = new UIImageView(new CGRect((WidthOfContentLeft - WidthOfImageLeft) / 2, (HeightOfContentLeft - HeightOfImageLeft) / 2, WidthOfImageLeft, HeightOfImageLeft));
                    ImageInside.ContentMode = UIViewContentMode.ScaleAspectFit;
                    ImageInside.Image = UIImage.FromBundle(icon).ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);

                    var ContentInside = new UIView(new CGRect(0, (Frame.Size.Height - HeightOfContentLeft) / 2, WidthOfContentLeft, HeightOfContentLeft));
                    ContentInside.AddSubview(ImageInside);

                    switch (aligment)
                    {
                        case SupportEntryDrawableInsideAligment.Left:
                            Control.LeftView = ContentInside;
                            Control.LeftViewMode = UITextFieldViewMode.Always;
                            break;
                        case SupportEntryDrawableInsideAligment.Right:
                            Control.RightView = ContentInside;
                            Control.RightViewMode = UITextFieldViewMode.Always;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}