using HighlightVideoOnline.Models.Objects.Formatters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HighlightVideoOnline.ViewModels
{
    public class MenuCategoryViewModel : BaseContentViewModel
    {
        private ObservableCollection<CategoryInfoFormatter> _CategoryInfoFormatters;
        public ObservableCollection<CategoryInfoFormatter> CategoryInfoFormatters
        {
            get { return _CategoryInfoFormatters; }
            set
            {
                _CategoryInfoFormatters = value;
                OnPropertyChanged(nameof(CategoryInfoFormatters));
            }
        }
        public MenuCategoryViewModel()
        {
            _CategoryInfoFormatters = new ObservableCollection<CategoryInfoFormatter>();
            Task.Factory.StartNew(async () =>
            {
                CategoryInfoFormatter item;
                for (int i = 0; i < 8; i++)
                {
                    item = new CategoryInfoFormatter() { Name = $"WWE {i}" };
                    item.GetSelectedItems += ItemSelected;
                    CategoryInfoFormatters.Add(item);
                    await Task.Delay(200);
                }

            });
        }

        public void ItemSelected(object obj)
        {
            var objC = obj;
        }

        public ICommand CloseCategoryMenu
        {
            get
            {
                return new Command(() =>
                {
                    App.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }
    }
}
