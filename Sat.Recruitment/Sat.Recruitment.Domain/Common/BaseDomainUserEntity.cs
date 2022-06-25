using System.ComponentModel.DataAnnotations.Schema;

namespace Sat.Recruitment.Domain.Common
{
    public abstract class BaseDomainUserEntity
    {
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; } = string.Empty;

        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; } = string.Empty;

        [Column(TypeName = "varchar(200)")]
        public string Address { get; set; } = string.Empty;

        [Column(TypeName = "varchar(50)")]
        public string Phone { get; set; } = string.Empty;

        [Column(TypeName = "date")]
        public DateTime LastModifiedDate { get; set; }
    }
}
