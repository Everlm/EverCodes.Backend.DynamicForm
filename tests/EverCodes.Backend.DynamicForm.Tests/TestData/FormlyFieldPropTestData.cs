using EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Entities.v2;

namespace EverCodes.Backend.DynamicForm.Tests.TestData
{
    public class FormlyFieldPropTestData
    {
        public static FormlyFieldProp CreateTextInputProp(string label, string placeholder, bool required = true)
        {
            return new FormlyFieldProp
            {
                Id = Guid.NewGuid(),
                Type = "text",
                Label = label,
                Placeholder = placeholder,
                Required = required,
                Disabled = false,
                Readonly = false,
                Appearance = "outline"
            };
        }

        public static FormlyFieldProp CreateUsernameProp()
        {
            return new FormlyFieldProp
            {
                Id = Guid.NewGuid(),
                Type = "text",
                Label = "Username",
                Placeholder = "Enter value for username",
                Required = true,
                Disabled = false,
                Readonly = false,
                MinLength = 3,
                MaxLength = 20,
                Appearance = "outline"
            };
        }

        public static FormlyFieldProp CreateEmailProp()
        {
            return new FormlyFieldProp
            {
                Id = Guid.NewGuid(),
                Type = "email",
                Label = "Email",
                Pattern = "^[a-zA-Z0-9._\\+%\\-]+@evercodes\\.com$",
                Placeholder = "Enter value for email",
                Required = true,
                Disabled = false,
                Readonly = false,
                Appearance = "outline"
            };
        }

        public static FormlyFieldProp CreatePasswordProp()
        {
            return new FormlyFieldProp
            {
                Id = Guid.NewGuid(),
                Type = "password",
                Label = "Password",
                Placeholder = "Enter value for password",
                Required = true,
                Disabled = false,
                Readonly = false,
                MinLength = 6,
                MaxLength = 20,
                Appearance = "outline"
            };
        }

        public static FormlyFieldProp CreateSelectProp(string label, List<FormlyFieldOption> options)
        {
            return new FormlyFieldProp
            {
                Id = Guid.NewGuid(),
                Label = label,
                Required = true,
                Disabled = false,
                Readonly = false,
                Appearance = "outline",
                Options = options
            };
        }
    }
}