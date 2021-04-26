using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeRenovationCalculator.ViewModel
{
    public class CoverParameterVM : BaseParamVM
    {
        public CoverParameterVM(string paramName)
            :base(paramName)
        {

        }

        double _ParamValue;
        public double ParamValue
        {
            get => _ParamValue;
            set => Set(ref _ParamValue, value);
        }
    }
}
