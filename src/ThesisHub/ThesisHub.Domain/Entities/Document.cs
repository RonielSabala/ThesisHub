using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThesisHub.Domain.Core;

namespace ThesisHub.Domain.Entities
{
    [Table("documents")]
    public class Document : BaseEntity
    {
        [Required]
        [Column("doc_name")]
        [StringLength(50)]
        public string DocName { get; set; }

        [Required]
        [Column("file_path")]
        [StringLength(250)]
        public string FilePath { get; set; }

        [Required]
        [Column("upload_date")]
        public DateTime UploadDate { get; set; }

        [Required]
        [Column("doc_status")]
        [StringLength(20)]
        public string DocStatus { get; set; }

        [Required]
        [Column("project_id")]
        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
