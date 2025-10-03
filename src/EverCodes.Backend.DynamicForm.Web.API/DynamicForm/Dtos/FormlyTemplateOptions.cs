
namespace EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Dtos
{
    public class FormlyTemplateOptions
    {
        public string Label { get; set; } = string.Empty;
        public bool Required { get; set; }
        public int? MinLength { get; set; }
        public int? MaxLength { get; set; }
        public string? Type { get; set; }  
        public string? Placeholder { get; set; }
        public List<FormlyOptionDto>? Options { get; set; }
    }
}