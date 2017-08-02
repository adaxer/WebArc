using PropertyChanged;
using Southwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
