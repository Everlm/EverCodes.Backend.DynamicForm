using EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Dtos;

namespace EverCodes.Backend.DynamicForm.Web.API.DynamicForm.MockData
{
    public class DynamicFormData
    {
        public static FormDefinitionDto GetFormDefinitionMockData()
        {
            return new FormDefinitionDto
            {
                FormName = "User",
                Fields = new List<FieldGroupDto>
                {
                    new FieldGroupDto
                    {
                        FieldGroupClassName = "display-grid",
                        FieldGroup = new List<FormlyFieldDto>
                        {
                            new FormlyFieldDto
                            {
                                Key = "username",
                                Type = "input",
                                ClassName = "col-6",
                                Props = new FormlyTemplateOptions
                                {
                                    Label = "Username",
                                    Required = true,
                                    MinLength = 3,
                                    MaxLength = 20,
                                    Type = "text",
                                    Placeholder = "Ingrese su usuario",
                                    Appearance = "outline"
                                }
                            },
                            new FormlyFieldDto
                            {
                                Key = "email",
                                Type = "input",
                                ClassName = "col-6",
                                Props = new FormlyTemplateOptions
                                {
                                    Label = "Email",
                                    Required = true,
                                    Type = "email",
                                    Placeholder = "ejemplo@correo.com",
                                    Appearance = "outline"
                                }
                            },
                            new FormlyFieldDto
                            {
                                Key = "password",
                                Type = "input",
                                ClassName = "col-6",
                                Props = new FormlyTemplateOptions
                                {
                                    Label = "Password",
                                    Required = true,
                                    MinLength = 6,
                                    Type = "password",
                                    Placeholder = "Ingrese su contraseña",
                                    Appearance = "outline"
                                }
                            },
                            new FormlyFieldDto
                            {
                                Key = "role",
                                Type = "select",
                                ClassName = "col-6",
                                Props = new FormlyTemplateOptions
                                {
                                    Label = "Rol",
                                    Required = true,
                                    Appearance = "outline",
                                    Options = new List<FormlyOptionDto>
                                    {
                                        new FormlyOptionDto { Value = "admin", Label = "Administrador" },
                                        new FormlyOptionDto { Value = "user", Label = "Usuario" }
                                    }
                                }
                            }

                        },



                    }
                },


            };
        }

    }
}