using EverCodes.Backend.DynamicForm.Web.API.DynamicForm.Entities.v2;

namespace EverCodes.Backend.DynamicForm.Web.API.DynamicForm.MockData
{
    public class SeedFormData
    {
        public static FormlyForm BuildDynamicForm()
        {
            var formId = Guid.NewGuid();
            var form = new FormlyForm
            {
                Id = formId,
                Name = "User",
                Description = "This is a sample dynamic form",
                Fields = new List<FormlyFieldConfig>()
            };

            // Field 1: Name
            var nameFieldId = Guid.NewGuid();
            var namePropsId = Guid.NewGuid();
            var nameField = new FormlyFieldConfig
            {
                Id = nameFieldId,
                Key = "name",
                Type = "input",
                FormlyFormId = formId,
                FormlyForm = form
            };
            var nameProps = new FormlyFieldProp
            {
                Id = namePropsId,
                Label = "Name",
                Type = "text",
                Placeholder = "Enter your name",
                Required = true,
                Disabled = false,
                Readonly = false,
                Appearance = "outline",
                MinLength = 3,
                MaxLength = 20,
                FormlyFieldConfigId = nameFieldId,
                FormlyFieldConfig = nameField
            };
            nameField.Props = nameProps;
            form.Fields.Add(nameField);

            // Field 2: Phone Number
            var phoneFieldId = Guid.NewGuid();
            var phonePropsId = Guid.NewGuid();
            var phoneField = new FormlyFieldConfig
            {
                Id = phoneFieldId,
                Key = "phonenumber",
                Type = "input",
                FormlyFormId = formId,
                FormlyForm = form
            };
            var phoneProps = new FormlyFieldProp
            {
                Id = phonePropsId,
                Type = "tel",
                Label = "Phone Number",
                Placeholder = "Enter your phone number",
                Required = true,
                Disabled = false,
                Readonly = false,
                Appearance = "outline",
                FormlyFieldConfigId = phoneFieldId,
                FormlyFieldConfig = phoneField
            };
            phoneField.Props = phoneProps;
            form.Fields.Add(phoneField);

            // Field 3: Field Group
            var fieldGroupId = Guid.NewGuid();
            var fieldGroup = new FormlyFieldConfig
            {
                Id = fieldGroupId,
                FieldGroupClassName = "display-grid",
                FormlyFormId = formId,
                FormlyForm = form,
                FieldGroup = new List<FormlyFieldConfig>()
            };

            // Field Group Child 1: Username
            var usernameFieldId = Guid.NewGuid();
            var usernamePropsId = Guid.NewGuid();
            var usernameField = new FormlyFieldConfig
            {
                Id = usernameFieldId,
                Key = "username",
                Type = "input",
                ClassName = "col-6",
                FormlyFormId = formId,
                FormlyForm = form,
                ParentId = fieldGroupId,
                FormlyFieldConfigParent = fieldGroup
            };
            var usernameProps = new FormlyFieldProp
            {
                Id = usernamePropsId,
                Type = "text",
                Label = "Username",
                Placeholder = "Enter value for username",
                Required = true,
                Disabled = false,
                Readonly = false,
                MinLength = 3,
                MaxLength = 20,
                Appearance = "outline",
                FormlyFieldConfigId = usernameFieldId,
                FormlyFieldConfig = usernameField
            };
            usernameField.Props = usernameProps;
            fieldGroup.FieldGroup.Add(usernameField);

            // Field Group Child 2: Email
            var emailFieldId = Guid.NewGuid();
            var emailPropsId = Guid.NewGuid();
            var emailValidationId = Guid.NewGuid();
            var emailField = new FormlyFieldConfig
            {
                Id = emailFieldId,
                Key = "email",
                Type = "input",
                ClassName = "col-6",
                FormlyFormId = formId,
                FormlyForm = form,
                ParentId = fieldGroupId,
                FormlyFieldConfigParent = fieldGroup
            };
            var emailProps = new FormlyFieldProp
            {
                Id = emailPropsId,
                Label = "Email",
                Type = "email",
                Pattern = "^[a-zA-Z0-9._\\+%\\-]+@evercodes\\.com$",
                Placeholder = "Enter value for email",
                Required = true,
                Disabled = false,
                Readonly = false,
                Appearance = "outline",
                FormlyFieldConfigId = emailFieldId,
                FormlyFieldConfig = emailField
            };
            var emailValidation = new FormlyValidation
            {
                Id = emailValidationId,
                Messages = new Dictionary<string, string>
                {
                    { "required", "Este campo es obligatorio()Backend" },
                    { "pattern", "El correo debe pertenecer al dominio evercodes.com()Backend" }
                },
                FormlyFieldConfigId = emailFieldId,
                FormlyFieldConfig = emailField
            };
            emailField.Props = emailProps;
            emailField.Validation = emailValidation;
            fieldGroup.FieldGroup.Add(emailField);

            // Field Group Child 3: Password
            var passwordFieldId = Guid.NewGuid();
            var passwordPropsId = Guid.NewGuid();
            var passwordValidationId = Guid.NewGuid();
            var passwordField = new FormlyFieldConfig
            {
                Id = passwordFieldId,
                Key = "password",
                Type = "input",
                ClassName = "col-6",
                FormlyFormId = formId,
                FormlyForm = form,
                ParentId = fieldGroupId,
                FormlyFieldConfigParent = fieldGroup
            };
            var passwordProps = new FormlyFieldProp
            {
                Id = passwordPropsId,
                Label = "Password",
                Type = "password",
                Placeholder = "Enter value for password",
                Required = true,
                Disabled = false,
                Readonly = false,
                MinLength = 6,
                MaxLength = 20,
                Appearance = "outline",
                FormlyFieldConfigId = passwordFieldId,
                FormlyFieldConfig = passwordField
            };
            var passwordValidation = new FormlyValidation
            {
                Id = passwordValidationId,
                Messages = new Dictionary<string, string>
                {
                    { "required", "Este campo es obligatorio()Backend" },
                    { "minlength", "Mínimo 6 caracteres()Backend" },
                    { "maxlength", "Máximo 20 caracteres()Backend" }
                },
                FormlyFieldConfigId = passwordFieldId,
                FormlyFieldConfig = passwordField
            };
            passwordField.Props = passwordProps;
            passwordField.Validation = passwordValidation;
            fieldGroup.FieldGroup.Add(passwordField);

            // Field Group Child 4: Role
            var roleFieldId = Guid.NewGuid();
            var rolePropsId = Guid.NewGuid();
            var roleField = new FormlyFieldConfig
            {
                Id = roleFieldId,
                Key = "role",
                Type = "select",
                ClassName = "col-6",
                FormlyFormId = formId,
                FormlyForm = form,
                ParentId = fieldGroupId,
                FormlyFieldConfigParent = fieldGroup
            };
            var roleProps = new FormlyFieldProp
            {
                Id = rolePropsId,
                Label = "Role",
                Required = true,
                Disabled = false,
                Readonly = false,
                Appearance = "outline",
                FormlyFieldConfigId = roleFieldId,
                FormlyFieldConfig = roleField,
                Options = new List<FormlyFieldOption>()
            };

            var adminOption = new FormlyFieldOption
            {
                Id = Guid.NewGuid(),
                Value = "admin",
                Label = "Administrator",
                FormlyFieldPropId = rolePropsId,
                FormlyFieldProp = roleProps
            };
            var userOption = new FormlyFieldOption
            {
                Id = Guid.NewGuid(),
                Value = "user",
                Label = "User",
                FormlyFieldPropId = rolePropsId,
                FormlyFieldProp = roleProps
            };
            var guestOption = new FormlyFieldOption
            {
                Id = Guid.NewGuid(),
                Value = "guest",
                Label = "Guest",
                FormlyFieldPropId = rolePropsId,
                FormlyFieldProp = roleProps
            };

            roleProps.Options.Add(adminOption);
            roleProps.Options.Add(userOption);
            roleProps.Options.Add(guestOption);

            roleField.Props = roleProps;
            fieldGroup.FieldGroup.Add(roleField);

            form.Fields.Add(fieldGroup);

            return form;
        }
    }
}