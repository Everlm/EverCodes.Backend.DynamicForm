namespace EverCodes.Backend.DynamicForm.Web.API.DynamicForm.DTOs
{
    public class FormlyFieldConfigDto
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string Key { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string DefaultValue { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public string FieldGroupClassName { get; set; } = string.Empty;
        public string Template { get; set; } = string.Empty;
        public bool Hide { get; set; }
        public bool ResetOnHide { get; set; }
        public bool Focus { get; set; }
        public FormlyValidationDto? Validation { get; set; }
        public FormlyValidatiorDto? Validator { get; set; }
        public FormlyFieldPropDto? Props { get; set; }
        public List<FormlyFieldConfigDto> FieldGroup { get; set; } = new();
        public List<string> Wrappers { get; set; } = new();
    }
}
