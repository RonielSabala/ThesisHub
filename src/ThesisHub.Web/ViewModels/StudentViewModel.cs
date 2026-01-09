using ThesisHub.Web.Models;

namespace ThesisHub.Web.ViewModels
{
    public class StudentViewModel : BaseEntityViewModel
    {
        public override List<FieldModel> StaticFields { get; set; } = new List<FieldModel>
        {
            new FieldModel { Id = "firstName", Label = "First Name" },
            new FieldModel { Id = "lastName", Label = "Last Name" },
            new FieldModel { Id = "email", Label = "Email" },
            new FieldModel { Id = "phone", Label = "Phone" },
            new FieldModel { Id = "department", Label = "Department"},
        };

        public override List<FieldModel> DynamicFields { get; set; } = new List<FieldModel>
        {
            new FieldModel { Type = "text", Placeholder = "the student's first name" },
            new FieldModel { Type = "text", Placeholder = "the student's last name" },
            new FieldModel { Type = "email", Placeholder = "an email" },
            new FieldModel { Type = "text", Placeholder = "the student's phone number" },
        };
    }
}
