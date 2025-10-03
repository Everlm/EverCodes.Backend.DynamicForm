
namespace src.EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Dtos
{
    public class FormDefinitionDto
    {
        public string FormName { get; set; } = string.Empty;
        public List<FormFieldDto> Fields { get; set; } = new();
    }
}