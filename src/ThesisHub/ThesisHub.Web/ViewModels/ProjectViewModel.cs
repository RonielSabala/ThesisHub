using ThesisHub.Web.Models;

namespace ThesisHub.Web.ViewModels
{
    public class ProjectViewModel : BaseEntityViewModel
    {
        public override List<FieldModel> StaticFields { get; set; } = new List<FieldModel>
        {
            new FieldModel { Id = "title", Label = "Title" },
            new FieldModel { Id = "projectDescription", Label = "Description" },
            new FieldModel { Id = "registrationDate", Label = "Created at" },
            new FieldModel { Id = "projectStatus", Label = "Status" },
            new FieldModel { Id = "student", Label = "Owner"},
        };

        public override List<FieldModel> DynamicFields { get; set; } = new List<FieldModel>
        {
            new FieldModel { Type = "text" },
            new FieldModel { Type = "text" },
            new FieldModel { Type = "datetime-local" },
            new FieldModel { Type = "text" },
        };
    }
}
