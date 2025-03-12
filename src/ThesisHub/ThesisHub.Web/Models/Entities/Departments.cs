using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThesisHub.Web.Models.Entities
{
    [Table("departments")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("dept_name")]
        [MinLength(3)]
        [MaxLength(50)]
        public string DeptName { get; set; }

        [Required]
        [Column("faculty_head")]
        [MinLength(3)]
        [MaxLength(50)]
        public string FacultyHead { get; set; }

        [Required]
        [Column("email")]
        [MinLength(3)]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
