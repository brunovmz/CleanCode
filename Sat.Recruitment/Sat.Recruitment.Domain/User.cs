
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sat.Recruitment.Domain.Common;

namespace Sat.Recruitment.Domain
{
    public class User : BaseDomainUserEntity 
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string UserType { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal Money { get; set; }

    }
}
