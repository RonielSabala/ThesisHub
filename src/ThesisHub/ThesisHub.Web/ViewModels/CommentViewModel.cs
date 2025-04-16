using ThesisHub.Web.Models;

namespace ThesisHub.Web.ViewModels
{
    public class CommentViewModel : BaseEntityViewModel
    {
        public override List<FieldModel> StaticFields { get; set; } = new List<FieldModel>
        {
            new FieldModel { Id = "commentText", Label = "Comment" },
            new FieldModel { Id = "uploadDate", Label = "Uploaded at" },
            new FieldModel { Id = "document", Label = "Document" },
            new FieldModel { Id = "tutor", Label = "Posted by" },
        };

        public override List<FieldModel> DynamicFields { get; set; } = new List<FieldModel>
        {
            new FieldModel { Type = "text", Placeholder = "a comment" },
            new FieldModel { Type = "datetime-local"},
        };
    }
}
