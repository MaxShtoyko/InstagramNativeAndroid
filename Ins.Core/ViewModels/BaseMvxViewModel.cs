using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ins.Core.ViewModels
{
    public class BaseMvxViewModel:MvxViewModel
    {
        private string _error;

        public string Error
        {
            get { return _error; }
            set
            {
                _error = value;
                RaisePropertyChanged();
            }
        }

    }
}
