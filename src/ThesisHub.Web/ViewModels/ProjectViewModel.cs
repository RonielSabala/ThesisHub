using ThesisHub.Web.Models;

namespace ThesisHub.Web.ViewModels
{
    public class ProjectViewModel : BaseEntityViewModel
    {
        public override List<FieldModel> StaticFields { get; set; } = new List<FieldModel>
        {
            new FieldModel { Id = "title", Label = "Title" },
            new FieldModel { Id = "projectDescription", Label = "Description" },
            new FieldModel { Id = "registrationDate", Label = "Creation Date" },
            new FieldModel { Id = "projectStatus", Label = "Status", Placeholder = "in progress" },
            new FieldModel { Id = "student", Label = "Owner"},
        };

        public override List<FieldModel> DynamicFields { get; set; } = new List<FieldModel>
        {
            new FieldModel { Type = "text", Placeholder = "a title" },
            new FieldModel { Type = "text", Placeholder = "a description" },
            new FieldModel { Type = "datetime-local"},
        };
    }
}
