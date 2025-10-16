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
                        Key = "username",
                        Type = "input",
                        DefaultValue = "Ever",
                        Props = new FormlyFieldProp
                        {
                            Id = Guid.NewGuid(),
                            Label = "Username",
                            Type = "text",
                            Placeholder = "Enter your username",
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
                        Key = "email",
                        Type = "input",
                        DefaultValue = "ever@example.com",
                        Props = new FormlyFieldProp
                        {
                            Id = Guid.NewGuid(),
                            Type = "email",
                            Label = "Email",
                            Placeholder = "Enter your email",
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
                                DefaultValue = "username",
                                ClassName = "col-6",
                                Props = new FormlyFieldProp
                                {
                                    Id = Guid.NewGuid(),
                                    Type = "text",
                                    Label = "Username",
                                    Placeholder = "Enter value for username",
                                    Required = false,
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
                                DefaultValue = "email@example.com",
                                ClassName = "col-6",
                                Props = new FormlyFieldProp
                                {
                                    Id = Guid.NewGuid(),
                                    Label = "Email",
                                    Type = "email",
                                    Placeholder = "Enter value for email",
                                    Required = false,
                                    Disabled = false,
                                    Readonly = false,
                                    Appearance = "outline"

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
                                    Required = false,
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