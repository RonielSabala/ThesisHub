using ThesisHub.Web.Models;

namespace ThesisHub.Web.ViewModels
{
    public class CommentViewModel : BaseEntityViewModel
    {
        public override List<FieldModel> StaticFields { get; set; } = new List<FieldModel>
        {
            new FieldModel { Id = "commentText", Label = "Comment" },
            new FieldModel { Id = "uploadDate", Label = "Published at" },
            new FieldModel { Id = "document", Label = "Project File" },
            new FieldModel { Id = "tutor", Label = "Tutor Reviewer" },
        };

        public override List<FieldModel> DynamicFields { get; set; } = new List<FieldModel>
        {
            new FieldModel { Type = "text", Placeholder = "a comment" },
            new FieldModel { Type = "datetime-local"},
        };
    }
}
