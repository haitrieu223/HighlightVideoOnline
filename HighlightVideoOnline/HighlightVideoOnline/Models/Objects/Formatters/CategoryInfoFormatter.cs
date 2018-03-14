using HighlightVideoOnline.Models.Objects.Infos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HighlightVideoOnline.Models.Objects.Formatters
{
    public class CategoryInfoFormatter : CategoryInfo
    {
        public Action<object> GetSelectedItems { get; set; }
        public ICommand OnSelected
        {
            get
            {
                return new Command((obj) =>
                {
                    GetSelectedItems?.Invoke(obj);
                });
            }
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            switch (propertyName)
            {
            }
        }

    }
}
