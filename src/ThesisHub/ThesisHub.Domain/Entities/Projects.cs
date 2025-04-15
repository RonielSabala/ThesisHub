using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThesisHub.Domain.Core;

namespace ThesisHub.Domain.Entities
{
    [Table("projects")]
    public class Project : BaseEntity
    {
        [Required]
        [Column("title")]
        [StringLength(50, MinimumLength = 1)]
        public string Title { get; set; }

        [Column("project_description")]
        [StringLength(250)]
        public string ProjectDescription { get; set; }

        [Required]
        [Column("registration_date")]
        public DateTime RegistrationDate { get; set; }

        [Required]
        [Column("project_status")]
        public string ProjectStatus { get; set; }

        [Required]
        [Column("student_id")]
        [Range(1, int.MaxValue)]
        public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}
