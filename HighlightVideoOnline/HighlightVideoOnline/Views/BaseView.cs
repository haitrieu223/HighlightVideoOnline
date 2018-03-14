using HighlightVideoOnline.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Xamarin.Forms;

namespace HighlightVideoOnline.Views
{
    public abstract class BaseView<T> : ContentPage where T : BaseViewModel
    {
        private BaseViewModel _viewModel;

        public BaseView()
        {
            _viewModel = App.unityContainer.Resolve<T>();
            BindingContext = _viewModel;
            _viewModel.Init();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.OnAppearing(this);
        }


        protected async override void OnDisappearing()
        {
            base.OnDisappearing();
            await _viewModel.OnDisappearing(this);
        }
    }
}
