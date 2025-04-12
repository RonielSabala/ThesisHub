using ThesisHub.Web.Models;

namespace ThesisHub.Web.ViewModels
{
    public class TutorViewModel : BaseEntityViewModel
    {
        public override List<FieldModel> StaticFields { get; set; } = new List<FieldModel>
        {
            new FieldModel { Id = "firstName", Label = "First Name" },
            new FieldModel { Id = "lastName", Label = "Last Name" },
            new FieldModel { Id = "email", Label = "Email" },
            new FieldModel { Id = "specialization", Label = "Specialization" },
            new FieldModel { Id = "department", Label = "Department"},
        };

        public override List<FieldModel> DynamicFields { get; set; } = new List<FieldModel>
        {
            new FieldModel { Type = "text" },
            new FieldModel { Type = "text" },
            new FieldModel { Type = "email" },
            new FieldModel { Type = "text" },
        };
    }
}
