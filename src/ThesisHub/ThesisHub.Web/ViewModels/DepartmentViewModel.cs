using ThesisHub.Web.Models;

namespace ThesisHub.Web.ViewModels
{
    public class DepartmentViewModel : BaseEntityViewModel
    {
        public override List<FieldModel> StaticFields { get; set; } = new List<FieldModel>
        {
            new FieldModel { Id = "deptName", Label = "Dept. Name" },
            new FieldModel { Id = "facultyHead", Label = "Faculty Head" },
            new FieldModel { Id = "email", Label = "Email" }
        };

        public override List<FieldModel> DynamicFields { get; set; } = new List<FieldModel>
        {
            new FieldModel { Type = "text", Placeholder = "a department name"},
            new FieldModel { Type = "text", Placeholder = "a faculty head" },
            new FieldModel { Type = "email", Placeholder = "an email" }
        };
    }
}
