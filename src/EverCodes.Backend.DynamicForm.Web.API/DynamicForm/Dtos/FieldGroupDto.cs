
namespace EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Dtos
{
    public class FieldGroupDto
    {
        public string FieldGroupClassName { get; set; } = string.Empty;
        public List<FormlyFieldDto> FieldGroup { get; set; } = new();
    }
}
