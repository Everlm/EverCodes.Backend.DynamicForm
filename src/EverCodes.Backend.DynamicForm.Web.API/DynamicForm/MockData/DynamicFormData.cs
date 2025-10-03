using src.EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Dtos;

namespace src.EverCodes.Backend.DynamicForm.Web.API.DynamicForm.MockData
{
    public class DynamicFormData
    {
        public static FormDefinitionDto GetFormDefinitionMockData()
        {
            return new FormDefinitionDto
            {
                FormName = "User Registration",
                Fields = new List<FormFieldDto>
                {
                    new FormFieldDto
                    {
                        Name = "username",
                        Label = "Username",
                        Type = "text",
                        Required = true,
                        MinLength = 3,
                        MaxLength = 20
                    },
                    new FormFieldDto
                    {
                        Name = "email",
                        Label = "Email",
                        Type = "email",
                        Required = true
                    },
                    new FormFieldDto
                    {
                        Name = "password",
                        Label = "Password",
                        Type = "password",
                        Required = true,
                        MinLength = 6
                    },
                    new FormFieldDto
                    {
                        Name = "role",
                        Label = "Rol",
                        Type = "select",
                        Required = true,
                        Options = new List<OptionDto>
                        {
                            new OptionDto { Value = "admin", Label = "Administrador" },
                            new OptionDto { Value = "user", Label = "Usuario" }
                        }
                    }
                }
            };
        }
    }
}