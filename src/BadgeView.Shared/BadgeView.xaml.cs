using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BadgeView.Shared
{
    public partial class BadgeView : Grid
    {
        public static BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(BadgeView), "0", propertyChanged: (bindable, oldVal, newVal) =>
        {
            var view = (BadgeView)bindable;
            var value = (string)newVal;
            view.BadgeLabel.Text = value;
            view.UpdateVisible(value);
        });

        public static BindableProperty TextColorProperty = BindableProperty.Create("TextColor", typeof(Color), typeof(BadgeView), Color.White, propertyChanged: (bindable, oldVal, newVal) =>
        {
            var view = (BadgeView)bindable;
            view.BadgeLabel.TextColor = (Color)newVal;
        });

        public static BindableProperty FontFamilyProperty = BindableProperty.Create("FontFamily", typeof(string), typeof(BadgeView), Label.FontFamilyProperty.DefaultValue, propertyChanged: (bindable, oldVal, newVal) =>
        {
            var view = (BadgeView)bindable;
            view.BadgeLabel.FontFamily = (string)newVal;
        });

        public static BindableProperty BadgeColorProperty = BindableProperty.Create("BadgeColor", typeof(Color), typeof(BadgeView), Color.Blue, propertyChanged: (bindable, oldVal, newVal) =>
        {
            var view = (BadgeView)bindable;
            view.BadgeCircle.BackgroundColor = (Color)newVal;
        });

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        public Color TextColor
        {
            get
            {
                return (Color)GetValue(TextColorProperty);
            }
            set
            {
                SetValue(TextColorProperty, value);
            }
        }

        public string FontFamily
        {
            get
            {
                return (string)GetValue(FontFamilyProperty);
            }
            set
            {
                SetValue(FontFamilyProperty, value);
            }
        }

        public Color BadgeColor
        {
            get
            {
                return (Color)GetValue(BadgeColorProperty);
            }
            set
            {
                SetValue(BadgeColorProperty, value);
            }
        }

        public void UpdateVisible(string value)
        {
            if (string.IsNullOrEmpty(value) || "0".Equals(value)) IsVisible = false;
            else IsVisible = true;
        }

        public BadgeView()
        {
            InitializeComponent();
            BadgeLabel.Text = Text;
            UpdateVisible(Text);
            BadgeLabel.TextColor = TextColor;
            BadgeLabel.FontFamily = FontFamily;
            BadgeCircle.BackgroundColor = BadgeColor;
        }
    }
}
