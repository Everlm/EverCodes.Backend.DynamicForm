
namespace EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Dtos
{
    public class FormlyFieldDto
    {
        public string Key { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public FormlyTemplateOptions Props { get; set; } = new();
    }
}