namespace ThesisHub.Common.Dtos
{
    public class ProjectTutorDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int TutorId { get; set; }
        public string TutorRole { get; set; }

        public string ProjectTitle { get; set; }
        public string TutorName { get; set; }
    }
}
