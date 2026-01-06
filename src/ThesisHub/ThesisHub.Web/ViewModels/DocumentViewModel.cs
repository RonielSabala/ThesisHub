using ThesisHub.Web.Models;

namespace ThesisHub.Web.ViewModels
{
    public class DocumentViewModel : BaseEntityViewModel
    {
        public override List<FieldModel> StaticFields { get; set; } = new List<FieldModel>
        {
            new FieldModel { Id = "docName", Label = "File Name" },
            new FieldModel { Id = "filePath", Label = "URL" },
            new FieldModel { Id = "uploadDate", Label = "Upload Date" },
            new FieldModel { Id = "docStatus", Label = "Status", Placeholder = "under review" },
            new FieldModel { Id = "project", Label = "Associated Project"},
        };

        public override List<FieldModel> DynamicFields { get; set; } = new List<FieldModel>
        {
            new FieldModel { Type = "text", Placeholder = "the name of the document" },
            new FieldModel { Type = "text", Placeholder = "the link of the document" },
            new FieldModel { Type = "datetime-local"},
        };
    }
}
