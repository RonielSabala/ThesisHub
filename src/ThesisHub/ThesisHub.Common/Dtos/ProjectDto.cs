namespace ThesisHub.Common.Dtos
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? ProjectDescription { get; set; } = "N/A";
        public DateTime RegistrationDate { get; set; }
        public string ProjectStatus { get; set; }
        public int StudentId { get; set; }

        public string StudentName { get; set; } = "N/A";
    }
}
