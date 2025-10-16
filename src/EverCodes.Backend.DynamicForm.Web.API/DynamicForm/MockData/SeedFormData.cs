using EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Entities.v2;

namespace EverCodes.Backend.DynamicForm.Web.API.DynamicForm.MockData
{
    public class SeedFormData
    {
        public static FormlyForm BuildDynamicForm()
        {
            var form = new FormlyForm
            {
                Id = Guid.NewGuid(),
                Name = "User",
                Description = "This is a sample dynamic form",
                Fields = new List<FormlyFieldConfig>
                {
                    new FormlyFieldConfig
                    {
                        Id = Guid.NewGuid(),
                        Key = "name",
                        Type = "input",
                        // DefaultValue = "Ever",
                        Props = new FormlyFieldProp
                        {
                            Id = Guid.NewGuid(),
                            Label = "Name",
                            Type = "text",
                            Placeholder = "Enter your name",
                            Required = true,
                            Disabled = false,
                            Readonly = false,
                            Appearance = "outline",
                            MinLength = 3,
                            MaxLength = 20
                        }
                    },
                    new FormlyFieldConfig
                    {
                        Id = Guid.NewGuid(),
                        Key = "phonenumber",
                        Type = "input",
                        // DefaultValue = "ever@example.com",
                        Props = new FormlyFieldProp
                        {
                            Id = Guid.NewGuid(),
                            Type = "tel",
                            Label = "Phone Number",
                            Placeholder = "Enter your phone number",
                            Required = true,
                            Disabled = false,
                            Readonly = false,
                            Appearance = "outline",
                        },
                    },
                    new FormlyFieldConfig
                    {
                        Id = Guid.NewGuid(),
                        FieldGroupClassName = "display-grid",
                        FieldGroup = new List<FormlyFieldConfig>()
                        {
                            new FormlyFieldConfig
                            {
                                Id = Guid.NewGuid(),
                                Key = "username",
                                Type = "input",
                                // DefaultValue = "username",
                                ClassName = "col-6",
                                Props = new FormlyFieldProp
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
                                }
                            },
                            new FormlyFieldConfig
                            {
                                Id = Guid.NewGuid(),
                                Key = "email",
                                Type = "input",
                                // DefaultValue = "email@example.com",
                                ClassName = "col-6",
                                Props = new FormlyFieldProp
                                {
                                    Id = Guid.NewGuid(),
                                    Label = "Email",
                                    Type = "email",
                                    Pattern = "^[a-zA-Z0-9._\\+%\\-]+@evercodes\\.com$",
                                    Placeholder = "Enter value for email",
                                    Required = true,
                                    Disabled = false,
                                    Readonly = false,
                                    Appearance = "outline"

                                },
                                Validation = new FormlyValidation
                                {
                                    Id = Guid.NewGuid(),
                                    Messages = new Dictionary<string, string>
                                    {
                                        { "required", "Este campo es obligatorio()Backend" },
                                        { "pattern", "El correo debe pertenecer al dominio evercodes.com()Backend" }
                                    }
                                }
                            },
                            new FormlyFieldConfig
                            {
                                Id = Guid.NewGuid(),
                                Key = "password",
                                Type = "input",
                                // DefaultValue = "email@example.com",
                                ClassName = "col-6",
                                Props = new FormlyFieldProp
                                {
                                    Id = Guid.NewGuid(),
                                    Label = "Password",
                                    Type = "password",
                                    Placeholder = "Enter value for password",
                                    Required = true,
                                    Disabled = false,
                                    Readonly = false,
                                    MinLength = 6,
                                    MaxLength = 20,
                                    Appearance = "outline"
                                },
                                Validation = new FormlyValidation
                                {
                                    Id = Guid.NewGuid(),
                                    Messages = new Dictionary<string, string>
                                    {
                                        { "required", "Este campo es obligatorio()Backend" },
                                        { "minlength", "Mínimo 6 caracteres()Backend" },
                                        { "maxlength", "Máximo 20 caracteres()Backend" }
                                    }
                                }
                            },
                            new FormlyFieldConfig
                            {
                                Id = Guid.NewGuid(),
                                Key = "role",
                                Type = "select",
                                ClassName = "col-6",
                                Props = new FormlyFieldProp
                                {
                                    Id = Guid.NewGuid(),
                                    Label = "Role",
                                    Required = true,
                                    Disabled = false,
                                    Readonly = false,
                                    Appearance = "outline",
                                    Options = new List<FormlyFieldOption>
                                    {
                                        new FormlyFieldOption {Id = Guid.NewGuid(), Value = "admin", Label = "Administrator" },
                                        new FormlyFieldOption {Id = Guid.NewGuid(), Value = "user", Label = "User" },
                                        new FormlyFieldOption {Id = Guid.NewGuid(), Value = "guest", Label = "Guest" }
                                    }

                                }
                            }
                        }
                    }
                }
            };

            return form;
        }
    }
}