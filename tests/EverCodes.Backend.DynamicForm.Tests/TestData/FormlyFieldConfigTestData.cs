using EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Entities.v2;

namespace EverCodes.Backend.DynamicForm.Tests.TestData
{
    public class FormlyFieldConfigTestData
    {
        public static FormlyFieldConfig CreateUsernameFieldConfig()
        {
            return new FormlyFieldConfig
            {
                Id = Guid.NewGuid(),
                Key = "username",
                Type = "input",
                ClassName = "col-6",
                Props = FormlyFieldPropTestData.CreateUsernameProp()
            };
        }

        public static FormlyFieldConfig CreateEmailFieldConfig()
        {
            return new FormlyFieldConfig
            {
                Id = Guid.NewGuid(),
                Key = "email",
                Type = "input",
                ClassName = "col-6",
                Props = FormlyFieldPropTestData.CreateEmailProp(),
                Validation = FormlyValidationTestData.CreateEmailValidation()
            };
        }

        public static FormlyFieldConfig CreatePasswordFieldConfig()
        {
            return new FormlyFieldConfig
            {
                Id = Guid.NewGuid(),
                Key = "password",
                Type = "input",
                ClassName = "col-6",
                Props = FormlyFieldPropTestData.CreatePasswordProp(),
                Validation = FormlyValidationTestData.CreatePasswordValidation()
            };
        }

        public static FormlyFieldConfig CreateRoleFieldConfig()
        {
            return new FormlyFieldConfig
            {
                Id = Guid.NewGuid(),
                Key = "role",
                Type = "select",
                ClassName = "col-6",
                Props = FormlyFieldPropTestData.CreateSelectProp("Role", FormlyFieldOptionTestData.CreateRoleOptions())
            };
        }

        public static FormlyFieldConfig CreateTextFieldConfig(string key, string label, string className = "col-12")
        {
            return new FormlyFieldConfig
            {
                Id = Guid.NewGuid(),
                Key = key,
                Type = "input",
                ClassName = className,
                Props = FormlyFieldPropTestData.CreateTextInputProp(label, $"Enter value for {label.ToLower()}")
            };
        }

        public static List<FormlyFieldConfig> CreateGroupFormlyFieldConfigData(Guid formlyFormId)
        {
            return new List<FormlyFieldConfig>
            {
                new FormlyFieldConfig
                {
                    Id = Guid.NewGuid(),
                    FieldGroupClassName = "display-grid",
                    FormlyFormId = formlyFormId,
                    FieldGroup = new List<FormlyFieldConfig>
                    {
                        CreateUsernameFieldConfig(),
                        CreateEmailFieldConfig(),
                        CreatePasswordFieldConfig(),
                        CreateRoleFieldConfig()
                    }
                }
            };
        }

        public static List<FormlyFieldConfig> CreateBasicFormFields()
        {
            return new List<FormlyFieldConfig>
            {
                CreateUsernameFieldConfig(),
                CreateEmailFieldConfig(),
                CreatePasswordFieldConfig()
            };
        }

        public static List<FormlyFieldConfig> CreateCompleteUserFormFields()
        {
            return new List<FormlyFieldConfig>
            {
                CreateUsernameFieldConfig(),
                CreateEmailFieldConfig(),
                CreatePasswordFieldConfig(),
                CreateRoleFieldConfig(),
                CreateTextFieldConfig("firstName", "First Name", "col-6"),
                CreateTextFieldConfig("lastName", "Last Name", "col-6"),

            };
        }

        public static FormlyFieldConfig CreateGroupField(Guid FormlyFormId, FormlyForm form)
        {
            return new FormlyFieldConfig
            {
                Id = Guid.NewGuid(),
                FieldGroupClassName = "user-details-group",
                FormlyFormId = FormlyFormId,
                FormlyForm = form,
                FieldGroup = new List<FormlyFieldConfig>()
            };
        }
        public static FormlyFieldConfig CreateCustomField(Guid FormlyFormId, FormlyForm form, string key, string type)
        {
            return new FormlyFieldConfig
            {
                Id = Guid.NewGuid(),
                Key = key,
                Type = type,
                FormlyFormId = FormlyFormId,
                FormlyForm = form
            };
        }

    }
}