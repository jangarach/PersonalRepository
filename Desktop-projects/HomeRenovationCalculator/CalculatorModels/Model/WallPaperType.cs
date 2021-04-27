using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeRenovationCalculator.Model
{
    [Table("WallPaperType")]
    public class WallPaperType : ObservableObject
    {
        public int Id { get; set; }

        string _Name;
        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }

        double _Rate;
        public double Rate
        {
            get => _Rate;
            set => Set(ref _Rate, value);
        }
    }
}
