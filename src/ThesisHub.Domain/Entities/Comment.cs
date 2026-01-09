using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThesisHub.Domain.Core;

namespace ThesisHub.Domain.Entities
{
    [Table("comments")]
    public class Comment : BaseEntity
    {
        [Required]
        [Column("comment_text")]
        [StringLength(500)]
        public string CommentText { get; set; }

        [Required]
        [Column("upload_date")]
        public DateTime UploadDate { get; set; }

        [Required]
        [Column("document_id")]
        [Range(1, int.MaxValue)]
        public int DocumentId { get; set; }

        [Required]
        [Column("tutor_id")]
        [Range(1, int.MaxValue)]
        public int TutorId { get; set; }

        public Document Document { get; set; }
        public Tutor Tutor { get; set; }
    }
}
