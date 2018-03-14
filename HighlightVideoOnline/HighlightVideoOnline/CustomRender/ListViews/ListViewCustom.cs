using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HighlightVideoOnline.CustomRender
{
    public class ListViewCustom : ListView
    {
        public ListViewCustom() : base(ListViewCachingStrategy.RecycleElement)
        {

        }

        public static readonly BindableProperty IsVisibleScrollProperty = BindableProperty.Create(nameof(IsVisibleScroll), typeof(bool), typeof(ListViewCustom), default(bool));
        public bool IsVisibleScroll
        {
            get { return (bool)GetValue(IsVisibleScrollProperty); }
            set { SetValue(IsVisibleScrollProperty, value); }
        }

        public static readonly BindableProperty IsScrollAllProperty = BindableProperty.Create(nameof(IsScrollAll), typeof(bool), typeof(ListViewCustom), default(bool));
        public bool IsScrollAll
        {
            get { return (bool)GetValue(IsScrollAllProperty); }
            set { SetValue(IsScrollAllProperty, value); }
        }
    }
}
