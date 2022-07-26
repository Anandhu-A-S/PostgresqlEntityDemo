using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostgresqlEntityDemo.Models
{
    public class College
    { 

        [DisplayName("ID")]
        public int CollegeId { get; set; }
        public string? Location { get; set; }
        [Column(Order = 2)]
        public string?  Name { get; set; }

    }
}
