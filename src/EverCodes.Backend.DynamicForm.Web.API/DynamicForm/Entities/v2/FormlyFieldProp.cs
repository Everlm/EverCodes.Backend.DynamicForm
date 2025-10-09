
namespace EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Entities.v2
{
    public class FormlyFieldProp
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public string Placeholder { get; set; } = string.Empty;
        public bool Disabled { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool Hidden { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public string Pattern { get; set; } = string.Empty;
        public bool Required { get; set; }
        public int Tabindex { get; set; }
        public bool Readonly { get; set; }
        public int Step { get; set; }
        public Dictionary<string, int>? Attributes { get; set; }
        public ICollection<FormlyFieldOption>? Options { get; set; }
        public Dictionary<string, object>? AdditionalProperties { get; set; }

    }
}