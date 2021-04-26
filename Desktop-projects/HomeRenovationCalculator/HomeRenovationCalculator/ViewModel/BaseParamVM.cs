using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeRenovationCalculator.ViewModel
{
    public class BaseParamVM : ViewModelBase
    {
        public BaseParamVM(string paramName)
        {
            this.ParamName = paramName;
        }
        public string ParamName { get; }
    }
}
