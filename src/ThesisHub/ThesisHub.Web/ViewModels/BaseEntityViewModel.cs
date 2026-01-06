using Microsoft.IdentityModel.Tokens;
using ThesisHub.Web.Models;

namespace ThesisHub.Web.ViewModels
{
    public class BaseEntityViewModel
    {
        public int Id { get; set; }
        public string EntityName { get; set; }
        public virtual string EntityPageName { get; set; }
        public virtual string EntityArticle { get; set; } = "a";
        public virtual List<FieldModel> StaticFields { get; set; } = new List<FieldModel>();
        public virtual List<FieldModel> DynamicFields { get; set; } = new List<FieldModel>();

        public BaseEntityViewModel()
        {
            for (int i = 0; i < DynamicFields.Count; i++)
            {
                var df = DynamicFields[i];
                var sf = StaticFields[i];
                df.Id = sf.Id;
                df.Label = sf.Label;

                if (df.Placeholder == null)
                {
                    df.Placeholder = sf.Label.ToLower();
                }
            }

            string fullClassName = this.GetType().Name;
            EntityName = fullClassName.EndsWith("ViewModel")
                ? fullClassName.Substring(0, fullClassName.Length - "ViewModel".Length)
                : fullClassName;

            if (EntityPageName.IsNullOrEmpty())
            {
                EntityPageName = EntityName;
            }
        }
    }
}
