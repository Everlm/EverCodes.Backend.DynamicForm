
namespace EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Entities.v2
{
    public class FormlyFieldConfig
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public Guid FormlyFormId { get; set; }
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
        public virtual FormlyValidation? Validation { get; set; }
        public virtual FormlyValidatior? Validator { get; set; }
        public virtual FormlyFieldProp? Props { get; set; }
        public virtual FormlyForm FormlyForm { get; set; } = null!;
        public virtual FormlyFieldConfig? FormlyFieldConfigParent { get; set; }
        public virtual ICollection<FormlyFieldConfig> FieldGroup { get; set; } = new List<FormlyFieldConfig>();
        public ICollection<string> Wrappers { get; set; } = new List<string>();

    }
}