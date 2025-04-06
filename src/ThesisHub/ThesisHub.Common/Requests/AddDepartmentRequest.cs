using ThesisHub.Common.core;

namespace ThesisHub.Common.Requests
{
    public class AddDepartmentRequest : BaseRequest
    {
        public string DeptName { get; set; }
        public string FacultyHead { get; set; }
        public string Email { get; set; }
    }
}
