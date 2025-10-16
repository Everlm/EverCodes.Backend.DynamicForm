namespace EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Entities.v2
{
    public class FormlyFieldOption
    {
        public Guid Id { get; set; }
        public Guid FormlyFieldPropId { get; set; }
        public string Value { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public virtual FormlyFieldProp FormlyFieldProp { get; set; } = null!;
    }
}