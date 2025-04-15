using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThesisHub.Domain.Core;

namespace ThesisHub.Domain.Entities
{
    [Table("tutors")]
    public class Tutor : BaseEntity
    {
        [Required]
        [Column("first_name")]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [Column("last_name")]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [Column("email")]
        [StringLength(50, MinimumLength = 3)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Column("specialization")]
        [StringLength(50, MinimumLength = 3)]
        public string Specialization { get; set; }

        [Required]
        [Column("department_id")]
        [Range(1, int.MaxValue)]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
