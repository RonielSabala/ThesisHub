using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThesisHub.Domain.Core;

namespace ThesisHub.Domain.Entities
{
    [Table("departments")]
    public class Department : BaseEntity
    {
        [Required]
        [Column("dept_name")]
        [StringLength(50, MinimumLength = 3)]
        public string DeptName { get; set; }

        [Required]
        [Column("faculty_head")]
        [StringLength(50, MinimumLength = 3)]
        public string FacultyHead { get; set; }

        [Required]
        [Column("email")]
        [StringLength(50, MinimumLength = 3)]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
