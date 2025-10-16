
namespace EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Entities.v2
{
    public class FormlyValidatior
    {
        public Guid Id { get; set; }
        public Guid FormlyFieldConfigId { get; set; }
        public string Name { get; set; } = string.Empty;
        public Dictionary<string, string> Messages { get; set; } = new();
        public FormlyFieldConfig FormlyFieldConfig { get; set; } = null!;
    }
}