using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HighlightVideoOnline.CustomRender
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LabelCustomBorder : ContentView
    {
        public static readonly BindableProperty TextLabelProperty = BindableProperty.Create("TextLabel", typeof(string), typeof(LabelCustomBorder), default(string),
            propertyChanged: (bindable, oldvalue, newvalue) =>
            {
                var label = (LabelCustomBorder)bindable;
                label.TextLabel = newvalue.ToString();
            });
        public string TextLabel
        {
            get { return (string)GetValue(TextLabelProperty); }
            set
            {
                SetValue(TextLabelProperty, value);
                lblBorder.Text = TextLabel;
            }
        }
        public static readonly BindableProperty FontSizeLabelProperty = BindableProperty.Create("FontSizeLabel", typeof(float), typeof(LabelCustomBorder), App.size_util.font_size_normal,
            propertyChanged: (bindable, oldvalue, newvalue) =>
            {
                var label = (LabelCustomBorder)bindable;
                label.FontSizeLabel = (float)newvalue;
            });
        public float FontSizeLabel
        {
            get { return (float)GetValue(FontSizeLabelProperty); }
            set
            {
                SetValue(FontSizeLabelProperty, value);
                lblBorder.FontSize = FontSizeLabel;
            }
        }

        public static readonly BindableProperty BorderColorLabelProperty = BindableProperty.Create("BorderColorLabel", typeof(Color), typeof(LabelCustomBorder), Color.Default,
        propertyChanged: (bindable, oldvalue, newvalue) =>
        {
            var label = (LabelCustomBorder)bindable;
            label.BorderColorLabel = (Color)newvalue;
        });
        public Color BorderColorLabel
        {
            get { return (Color)GetValue(BorderColorLabelProperty); }
            set
            {
                SetValue(BorderColorLabelProperty, value);
                frameBorder.BackgroundColor = BorderColorLabel;
            }
        }

        public static readonly BindableProperty BorderRadiusLabelProperty = BindableProperty.Create("BorderRadiusLabel", typeof(float), typeof(LabelCustomBorder), 0f,
        propertyChanged: (bindable, oldvalue, newvalue) =>
        {
            var label = (LabelCustomBorder)bindable;
            label.BorderRadiusLabel = (float)newvalue;
        });
        public float BorderRadiusLabel
        {
            get { return (float)GetValue(BorderRadiusLabelProperty); }
            set
            {
                SetValue(BorderRadiusLabelProperty, value);
                frameBorder.CornerRadius = BorderRadiusLabel;
            }
        }

        public static readonly BindableProperty FontAttributeLabelProperty = BindableProperty.Create("FontAttributesLabel", typeof(FontAttributes), typeof(LabelCustomBorder), FontAttributes.None,
            propertyChanged: (bindable, oldvalue, newvalue) =>
            {
                var label = (LabelCustomBorder)bindable;
                label.FontAttributesLabel = (FontAttributes)newvalue;
            });
        public FontAttributes FontAttributesLabel
        {
            get { return (FontAttributes)GetValue(FontAttributeLabelProperty); }
            set
            {
                SetValue(FontAttributeLabelProperty, value);
                lblBorder.FontAttributes = FontAttributesLabel;
            }
        }

        public static readonly BindableProperty TextColorLabelProperty = BindableProperty.CreateAttached("TextColorLabel", typeof(Color), typeof(LabelCustomBorder), Color.Default, propertyChanged: (bindable, oldvalue, newvalue) =>
        {
            var label = (LabelCustomBorder)bindable;
            label.TextColorLabel = (Color)newvalue;
        });
        public Color TextColorLabel
        {
            get { return (Color)GetValue(TextColorLabelProperty); }
            set
            {
                SetValue(TextColorLabelProperty, value);
                lblBorder.TextColor = TextColorLabel;
            }
        }

        public static readonly BindableProperty ValueLabelProperty = BindableProperty.CreateAttached("ValueLabel", typeof(object), typeof(LabelCustomBorder), default(object),
            propertyChanged: (bindable, oldvalue, newvalue) =>
            {
                var label = (LabelCustomBorder)bindable;
                label.ValueLabel = newvalue;
            });
        public object ValueLabel
        {
            get { return (object)GetValue(ValueLabelProperty); }
            set
            {
                SetValue(ValueLabelProperty, value);
            }
        }

        public static readonly BindableProperty BgColorLabelProperty = BindableProperty.CreateAttached("BgColorLabel", typeof(Color), typeof(LabelCustomBorder), Color.Default,
            propertyChanged: (bindable, oldvalue, newvalue) =>
            {
                var label = (LabelCustomBorder)bindable;
                label.BgColorLabel = (Color)newvalue;
            });
        public Color BgColorLabel
        {
            get { return (Color)GetValue(BgColorLabelProperty); }
            set
            {
                SetValue(BgColorLabelProperty, value);
                frameBg.BackgroundColor = BgColorLabel;
            }
        }

        public Action<object> EventClick { get; set; }

        public LabelCustomBorder()
        {
            InitializeComponent();
            GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {

                    UnTouch();
                    if (EventClick != null)
                        EventClick(ValueLabel);
                })
            });
        }

        private async void UnTouch()
        {
            try
            {
                var percent = (0.5f / 100f) * 3;
                frameEffect.IsVisible = true;
                for (int i = 1; i < 30; i++)
                {
                    frameEffect.Opacity = frameEffect.Opacity - percent;
                    await Task.Delay(1);
                }
                frameEffect.IsVisible = false;
                frameEffect.Opacity = 0.5f;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}