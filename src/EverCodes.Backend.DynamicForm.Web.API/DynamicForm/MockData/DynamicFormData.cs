using EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Dtos;

namespace EverCodes.Backend.DynamicForm.Web.API.DynamicForm.MockData
{
    public class DynamicFormData
    {
        public static FormDefinitionDto GetFormDefinitionMockData()
        {
            return new FormDefinitionDto
            {
                FormName = "User Registration",
                Fields = new List<FormlyFieldDto>
                {
                    new FormlyFieldDto
                    {
                        Key = "username",
                        Type = "input",
                        TemplateOptions = new FormlyTemplateOptions
                        {
                            Label = "Username",
                            Required = true,
                            MinLength = 3,
                            MaxLength = 20,
                            Type = "text",
                            Placeholder = "Ingrese su usuario"
                        }
                    },
                    new FormlyFieldDto
                    {
                        Key = "email",
                        Type = "input",
                        TemplateOptions = new FormlyTemplateOptions
                        {
                            Label = "Email",
                            Required = true,
                            Type = "email",
                            Placeholder = "ejemplo@correo.com"
                        }
                    },
                    new FormlyFieldDto
                    {
                        Key = "password",
                        Type = "input",
                        TemplateOptions = new FormlyTemplateOptions
                        {
                            Label = "Password",
                            Required = true,
                            MinLength = 6,
                            Type = "password",
                            Placeholder = "Ingrese su contraseña"
                        }
                    },
                    new FormlyFieldDto
                    {
                        Key = "role",
                        Type = "select",
                        TemplateOptions = new FormlyTemplateOptions
                        {
                            Label = "Rol",
                            Required = true,
                            Options = new List<FormlyOptionDto>
                            {
                                new FormlyOptionDto { Value = "admin", Label = "Administrador" },
                                new FormlyOptionDto { Value = "user", Label = "Usuario" }
                            }
                        }
                    }
                }
            };
        }

    }
}