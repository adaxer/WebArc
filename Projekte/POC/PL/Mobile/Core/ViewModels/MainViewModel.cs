using PropertyChanged;
using Southwind.Core.Commands;
using Southwind.Interfaces;
using Southwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Southwind.Core.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel
    {
        private ICategoryService categoryService;

        public MainViewModel(ICategoryService cats)
        {
            this.categoryService = cats;
        }

        public ICommand LoadCommand => new RelayCommand(DoLoad);

        public ICollection<Category> Categories { get; private set; }

        private async void DoLoad(object obj)
        {
            var cats = await Task.Factory.StartNew<IEnumerable<Category>>(()=> categoryService.LoadCategories());
            Categories = new List<Category>(cats);
        }
    }
}
