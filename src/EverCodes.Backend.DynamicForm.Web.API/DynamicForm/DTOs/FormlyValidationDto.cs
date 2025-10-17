namespace EverCodes.Backend.DynamicForm.Web.API.DynamicForm.DTOs
{
    public class FormlyValidationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Dictionary<string, string> Messages { get; set; } = new();
        public bool Show { get; set; }
    }
}
