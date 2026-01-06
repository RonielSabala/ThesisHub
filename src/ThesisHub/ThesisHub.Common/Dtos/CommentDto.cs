namespace ThesisHub.Common.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public DateTime UploadDate { get; set; }
        public int DocumentId { get; set; }
        public int TutorId { get; set; }

        public string DocName { get; set; } = "N/A";
        public string TutorName { get; set; } = "N/A";
    }
}
