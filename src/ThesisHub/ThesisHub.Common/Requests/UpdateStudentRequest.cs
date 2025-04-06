using ThesisHub.Common.core;

namespace ThesisHub.Common.Requests
{
    public class UpdateStudentRequest : BaseRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
    }
}
