using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace HighlightVideoOnline.ViewModels
{
    /// <summary>
    /// BaseContentViewModel dành cho các contentview binding viewmodel
    /// </summary>
    public abstract class BaseContentViewModel : INotifyPropertyChanged
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
    }
}
