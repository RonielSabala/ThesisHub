namespace ThesisHub.Common.Dtos
{
    public class TutorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Specialization { get; set; }
        public int DepartmentId { get; set; }

        public string DeptName { get; set; } = "N/A";
    }
}
