using ThesisHub.Web.Models;

namespace ThesisHub.Web.ViewModels
{
    public class ProjectTutorViewModel : BaseEntityViewModel
    {
        public override List<FieldModel> StaticFields { get; set; } = new List<FieldModel>
        {
            new FieldModel { Id = "project", Label = "Project", Placeholder = "a project" },
            new FieldModel { Id = "tutor", Label = "Tutor", Placeholder = "a tutor" },
            new FieldModel { Id = "tutorRole", Label = "Tutor Role", Placeholder = "the tutor role" },
        };

        public virtual List<FieldModel> DynamicFields { get; set; } = new List<FieldModel>();
    }
}
