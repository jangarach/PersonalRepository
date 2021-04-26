using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeRenovationCalculator.Model
{
    [Table("WallPaper")]
    public class WallPaper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public double Price { get; set; }
    }
}
