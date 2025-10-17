using EverCodes.Backend.DynamicForm.Web.API.DynamicForm.DTOs;
using EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Entities.v2;

namespace EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Mappers
{
    public static class FormlyMapper
    {
        public static FormlyFormDto ToDto(FormlyForm form)
        {
            return new FormlyFormDto
            {
                Id = form.Id,
                Name = form.Name,
                Description = form.Description,
                Fields = form.Fields.Select(ToFieldDto).ToList()
            };
        }

        public static FormlyFieldConfigDto ToFieldDto(FormlyFieldConfig field)
        {
            return new FormlyFieldConfigDto
            {
                Id = field.Id,
                ParentId = field.ParentId,
                Key = field.Key,
                Type = field.Type,
                DefaultValue = field.DefaultValue,
                Name = field.Name,
                ClassName = field.ClassName,
                FieldGroupClassName = field.FieldGroupClassName,
                Template = field.Template,
                Hide = field.Hide,
                ResetOnHide = field.ResetOnHide,
                Focus = field.Focus,
                Validation = field.Validation != null ? ToValidationDto(field.Validation) : null,
                Validator = field.Validator != null ? ToValidatorDto(field.Validator) : null,
                Props = field.Props != null ? ToPropDto(field.Props) : null,
                FieldGroup = field.FieldGroup.Select(ToFieldDto).ToList(),
                Wrappers = field.Wrappers.ToList()
            };
        }

        public static FormlyFieldPropDto ToPropDto(FormlyFieldProp props)
        {
            return new FormlyFieldPropDto
            {
                Id = props.Id,
                Type = props.Type,
                Label = props.Label,
                Placeholder = props.Placeholder,
                Disabled = props.Disabled,
                Rows = props.Rows,
                Cols = props.Cols,
                Description = props.Description,
                Hidden = props.Hidden,
                Max = props.Max,
                Min = props.Min,
                MinLength = props.MinLength,
                MaxLength = props.MaxLength,
                Pattern = props.Pattern,
                Required = props.Required,
                Tabindex = props.Tabindex,
                Readonly = props.Readonly,
                Step = props.Step,
                Appearance = props.Appearance,
                Attributes = props.Attributes,
                AdditionalProperties = props.AdditionalProperties,
                Options = props.Options.Select(ToOptionDto).ToList()
            };
        }

        public static FormlyFieldOptionDto ToOptionDto(FormlyFieldOption option)
        {
            return new FormlyFieldOptionDto
            {
                Id = option.Id,
                Value = option.Value,
                Label = option.Label
            };
        }

        public static FormlyValidationDto ToValidationDto(FormlyValidation validation)
        {
            return new FormlyValidationDto
            {
                Id = validation.Id,
                Name = validation.Name,
                Messages = new Dictionary<string, string>(validation.Messages),
                Show = validation.Show
            };
        }

        public static FormlyValidatiorDto ToValidatorDto(FormlyValidatior validator)
        {
            return new FormlyValidatiorDto
            {
                Id = validator.Id,
                Name = validator.Name,
                Messages = new Dictionary<string, string>(validator.Messages)
            };
        }
    }
}
