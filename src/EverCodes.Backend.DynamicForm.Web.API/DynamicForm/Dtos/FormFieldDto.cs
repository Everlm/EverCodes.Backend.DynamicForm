
namespace src.EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Dtos
{
    public class FormFieldDto
    {
        public string Name { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public bool Required { get; set; }
        public int? MinLength { get; set; }
        public int? MaxLength { get; set; }
        public string? Value { get; set; }
        public List<OptionDto>? Options { get; set; }
    }
}