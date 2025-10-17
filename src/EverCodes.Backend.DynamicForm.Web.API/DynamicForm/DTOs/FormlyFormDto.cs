namespace EverCodes.Backend.DynamicForm.Web.API.DynamicForm.DTOs
{
    public class FormlyFormDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<FormlyFieldConfigDto> Fields { get; set; } = new();
    }
}
