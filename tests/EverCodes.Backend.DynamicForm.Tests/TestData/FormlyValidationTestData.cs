using EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Entities.v2;

namespace EverCodes.Backend.DynamicForm.Tests.TestData
{
    public class FormlyValidationTestData
    {
        public static FormlyValidation CreateRequiredValidation()
        {
            return new FormlyValidation
            {
                Id = Guid.NewGuid(),
                Messages = new Dictionary<string, string>
                {
                    { "required", "Este campo es obligatorio()Backend" }
                }
            };
        }

        public static FormlyValidation CreateEmailValidation()
        {
            return new FormlyValidation
            {
                Id = Guid.NewGuid(),
                Messages = new Dictionary<string, string>
                {
                    { "required", "Este campo es obligatorio()Backend" },
                    { "pattern", "El correo debe pertenecer al dominio evercodes.com()Backend" }
                }
            };
        }

        public static FormlyValidation CreatePasswordValidation()
        {
            return new FormlyValidation
            {
                Id = Guid.NewGuid(),
                Messages = new Dictionary<string, string>
                {
                    { "required", "Este campo es obligatorio()Backend" },
                    { "minlength", "Mínimo 6 caracteres()Backend" },
                    { "maxlength", "Máximo 20 caracteres()Backend" }
                }
            };
        }

        public static FormlyValidation CreateLengthValidation(int minLength, int maxLength)
        {
            return new FormlyValidation
            {
                Id = Guid.NewGuid(),
                Messages = new Dictionary<string, string>
                {
                    { "required", "Este campo es obligatorio()Backend" },
                    { "minlength", $"Mínimo {minLength} caracteres()Backend" },
                    { "maxlength", $"Máximo {maxLength} caracteres()Backend" }
                }
            };
        }

        public static FormlyValidation CreatePatternValidation(string patternMessage)
        {
            return new FormlyValidation
            {
                Id = Guid.NewGuid(),
                Messages = new Dictionary<string, string>
                {
                    { "required", "Este campo es obligatorio()Backend" },
                    { "pattern", patternMessage }
                }
            };
        }

        public static FormlyValidation CreateCustomValidation(Dictionary<string, string> messages)
        {
            return new FormlyValidation
            {
                Id = Guid.NewGuid(),
                Messages = messages
            };
        }
    }
}