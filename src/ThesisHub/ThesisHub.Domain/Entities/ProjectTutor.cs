using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThesisHub.Domain.Core;

namespace ThesisHub.Domain.Entities
{
    [Table("project_tutors")]
    public class ProjectTutor : BaseEntity
    {
        [Required]
        [Column("project_id")]
        [Range(1, int.MaxValue)]
        public int ProjectId { get; set; }

        [Required]
        [Column("tutor_id")]
        [Range(1, int.MaxValue)]
        public int TutorId { get; set; }

        [Required]
        [Column("tutor_role")]
        [StringLength(50, MinimumLength = 1)]
        public string TutorRole { get; set; }

        public Project Project { get; set; }
        public Tutor Tutor { get; set; }
    }
}
