using ThesisHub.Web.Models;

namespace ThesisHub.Web.ViewModels
{
    public class DocumentViewModel : BaseEntityViewModel
    {
        public override List<FieldModel> StaticFields { get; set; } = new List<FieldModel>
        {
            new FieldModel { Id = "docName", Label = "Doc. Name" },
            new FieldModel { Id = "filePath", Label = "Link" },
            new FieldModel { Id = "uploadDate", Label = "Uploaded at" },
            new FieldModel { Id = "docStatus", Label = "Status", Placeholder = "under review" },
            new FieldModel { Id = "project", Label = "Parent Project"},
        };

        public override List<FieldModel> DynamicFields { get; set; } = new List<FieldModel>
        {
            new FieldModel { Type = "text" },
            new FieldModel { Type = "text" },
            new FieldModel { Type = "datetime-local"},
        };
    }
}
