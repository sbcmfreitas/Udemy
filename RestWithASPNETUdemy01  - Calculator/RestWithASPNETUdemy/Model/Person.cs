using System;
using System.Collections.Generic;
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
        public string FisrtName { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("Gender")]
        public string Gender { get; set; }
        
    }
}
