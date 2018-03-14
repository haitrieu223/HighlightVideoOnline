using HighlightVideoOnline.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HighlightVideoOnline.ViewModels
{
    /// <summary>
    /// BaseViewModel dành cho các contentpage binding viewmodel
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public bool IsBusy { get; set; }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public virtual void Init()
        {
        }

        public async virtual Task OnAppearing(Page sender)
        {
        }

        public async virtual Task OnDisappearing(Page sender)
        {
        }
    }
}
