
namespace EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Entities.v2
{
    public class FormlyValidatior
    {
        public Guid Id { get; set; }
        public Guid FormlyFieldConfigId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public FormlyFieldConfig FormlyFieldConfig { get; set; } = null!;
    }
}