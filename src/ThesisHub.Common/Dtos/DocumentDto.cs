namespace ThesisHub.Common.Dtos
{
    public class DocumentDto
    {
        public int Id { get; set; }
        public string DocName { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadDate { get; set; }
        public string DocStatus { get; set; }
        public int ProjectId { get; set; }

        public string ProjectTitle { get; set; } = "N/A";
    }
}
