using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpCaliburnMicro1.ViewModels
{
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive
    {
        public IScreen ActiveItem { get; set; }
        public ShellViewModel(HomeViewModel home)
        {
            ActiveItem = home;
        }



    }
}
