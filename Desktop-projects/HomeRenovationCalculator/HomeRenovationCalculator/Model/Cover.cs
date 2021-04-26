using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeRenovationCalculator.Model
{
    [Table("Covers")]
    public class Cover
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int TypeId { get; set; }

        [ForeignKey("TypeId")]
        public CoverType CoverType { get; set; }

    }
}
