using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HighlightVideoOnline.CustomRender
{
    public class FrameButton : Frame
    {
        //public Command OnClick
        //{
        //    get { return (Command)GetValue(OnClickProperty); }
        //    set { SetValue(OnClickProperty, value); }
        //}
        //public static readonly BindableProperty OnClickProperty = BindableProperty.Create(nameof(OnClick), typeof(FrameButton), typeof(ICommand), default(ICommand));

        //public object Item
        //{
        //    get { return (object)GetValue(ItemProperty); }
        //    set { SetValue(ItemProperty, value); }
        //}
        //public static readonly BindableProperty ItemProperty = BindableProperty.Create(nameof(Item), typeof(FrameButton), typeof(object), default(object));

        private bool IsBusy = false;
        public Action Clicked { get; set; }
        protected async void OnClicked()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await this.FadeTo(0.2f, 400, Easing.CubicOut);
                await this.FadeTo(1, 200, Easing.CubicIn);
                Clicked?.Invoke();
                IsBusy = false;
            }
        }
        public FrameButton()
        {
            GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { OnClicked(); }) });
        }
    }
}
