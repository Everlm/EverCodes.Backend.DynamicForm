
namespace EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Entities.v2
{
    public class FormlyFieldConfig
    {
        public Guid Id { get; set; }
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
        public object Model { get; set; } = new object();
        public object Form { get; set; } = new object();
        public FormlyFieldProp Props { get; set; } = new FormlyFieldProp();
        public FormlyValidation? Validation { get; set; }
        public FormlyValidatior? Validator { get; set; }
        public FormlyFieldConfig? Parent { get; set; }
        public ICollection<string> Wrappers { get; set; } = new List<string>();
        public ICollection<FormlyFieldConfig> FieldGroup { get; set; } = new List<FormlyFieldConfig>();

    }
}