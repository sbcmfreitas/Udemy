using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Model
{
    [Table("person")]
    public class Person
    {
        [Column("Id")]
        public long Id { get; set; }

        [Column("FirstName")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,50}$", ErrorMessage = "Required Field {0} only allows characters with a 50-letter limit."),Required]
        public string FisrtName { get; set; }

        [Column("LastName")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,50}$", ErrorMessage = "Required Field {0} only allows characters with a 50-letter limit."), Required]
        public string LastName { get; set; }

        [Column("Gender")]
        [RegularExpression(@"^[(M|F|N)''-'\s]{1}$", ErrorMessage = "Required Field {0} only allows characters M, F or N."), Required]
        public string Gender { get; set; }
        
    }
}
