using System.ComponentModel.DataAnnotations.Schema;

namespace Sat.Recruitment.Domain.Common
{
    public abstract class BaseDomainUserEntity
    {
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Address { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Phone { get; set; }

        [Column(TypeName = "date")]
        public DateTime LastModifiedDate { get; set; }
    }
}
