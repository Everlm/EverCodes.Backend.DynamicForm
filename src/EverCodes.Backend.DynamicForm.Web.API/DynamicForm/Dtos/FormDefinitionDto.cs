
namespace EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Dtos
{
    public class FormDefinitionDto
    {
        public string FormName { get; set; } = string.Empty;
        public List<FormlyFieldDto> Fields { get; set; } = new();
    }
}