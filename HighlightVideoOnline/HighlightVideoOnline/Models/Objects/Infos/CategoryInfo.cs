using HighlightVideoOnline.Models.CRUD.Servers;
using HighlightVideoOnline.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HighlightVideoOnline.Models.Objects.Infos
{
    public class CategoryInfo : BaseObjects
    {
        private ICategoryRepository _categoryRepository;
        public int Id { get; set; }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private bool _IsVisible;
        public bool IsVisible
        {
            get { return _IsVisible; }
            set
            {
                _IsVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        public CategoryInfo()
        {
        }

        public CategoryInfo(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

    }
}
