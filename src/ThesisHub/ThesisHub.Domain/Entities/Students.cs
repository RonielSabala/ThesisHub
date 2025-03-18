using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThesisHub.Domain.Entities
{
    [Table("students")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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
        [Column("phone")]
        [StringLength(15, MinimumLength = 10)]
        public string Phone { get; set; }

        [Required]
        [Column("department_id")]
        [Range(1, int.MaxValue)]
        public int DepartmentId { get; set; }
    }
}
