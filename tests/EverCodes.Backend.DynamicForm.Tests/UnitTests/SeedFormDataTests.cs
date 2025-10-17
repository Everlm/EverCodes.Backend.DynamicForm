using EverCodes.Backend.DynamicForm.Web.API.DynamicForm.MockData;
using Xunit;

namespace EverCodes.Backend.DynamicForm.Tests.UnitTests
{
    public class SeedFormDataTests
    {
        [Fact]
        public void BuildDynamicForm_ShouldHaveCorrectFormStructure()
        {
            // Act
            var form = SeedFormData.BuildDynamicForm();

            // Assert
            Assert.NotNull(form);
            Assert.Equal("User", form.Name);
            Assert.Equal("This is a sample dynamic form", form.Description);
            Assert.Equal(3, form.Fields.Count);
        }

        [Fact]
        public void BuildDynamicForm_NameField_ShouldHaveCorrectRelationships()
        {
            // Act
            var form = SeedFormData.BuildDynamicForm();
            var nameField = form.Fields.First(f => f.Key == "name");

            // Assert - Field to Form relationship
            Assert.Equal(form.Id, nameField.FormlyFormId);
            Assert.Same(form, nameField.FormlyForm);

            // Assert - Field to Props relationship
            Assert.NotNull(nameField.Props);
            Assert.Equal(nameField.Id, nameField.Props.FormlyFieldConfigId);
            Assert.Same(nameField, nameField.Props.FormlyFieldConfig);
        }

        [Fact]
        public void BuildDynamicForm_PhoneField_ShouldHaveCorrectRelationships()
        {
            // Act
            var form = SeedFormData.BuildDynamicForm();
            var phoneField = form.Fields.First(f => f.Key == "phonenumber");

            // Assert - Field to Form relationship
            Assert.Equal(form.Id, phoneField.FormlyFormId);
            Assert.Same(form, phoneField.FormlyForm);

            // Assert - Field to Props relationship
            Assert.NotNull(phoneField.Props);
            Assert.Equal(phoneField.Id, phoneField.Props.FormlyFieldConfigId);
            Assert.Same(phoneField, phoneField.Props.FormlyFieldConfig);
            Assert.Equal("tel", phoneField.Props.Type);
        }

        [Fact]
        public void BuildDynamicForm_FieldGroup_ShouldHaveCorrectStructure()
        {
            // Act
            var form = SeedFormData.BuildDynamicForm();
            var fieldGroup = form.Fields.First(f => !string.IsNullOrEmpty(f.FieldGroupClassName));

            // Assert
            Assert.Equal("display-grid", fieldGroup.FieldGroupClassName);
            Assert.Equal(4, fieldGroup.FieldGroup.Count);
            Assert.Equal(form.Id, fieldGroup.FormlyFormId);
            Assert.Same(form, fieldGroup.FormlyForm);
        }

        [Fact]
        public void BuildDynamicForm_UsernameField_ShouldHaveCorrectRelationships()
        {
            // Act
            var form = SeedFormData.BuildDynamicForm();
            var fieldGroup = form.Fields.First(f => !string.IsNullOrEmpty(f.FieldGroupClassName));
            var usernameField = fieldGroup.FieldGroup.First(f => f.Key == "username");

            // Assert - Parent-Child relationship
            Assert.Equal(fieldGroup.Id, usernameField.ParentId);
            Assert.Same(fieldGroup, usernameField.FormlyFieldConfigParent);

            // Assert - Field to Form relationship
            Assert.Equal(form.Id, usernameField.FormlyFormId);
            Assert.Same(form, usernameField.FormlyForm);

            // Assert - Field to Props relationship
            Assert.NotNull(usernameField.Props);
            Assert.Equal(usernameField.Id, usernameField.Props.FormlyFieldConfigId);
            Assert.Same(usernameField, usernameField.Props.FormlyFieldConfig);
        }

        [Fact]
        public void BuildDynamicForm_EmailField_ShouldHaveCorrectRelationships()
        {
            // Act
            var form = SeedFormData.BuildDynamicForm();
            var fieldGroup = form.Fields.First(f => !string.IsNullOrEmpty(f.FieldGroupClassName));
            var emailField = fieldGroup.FieldGroup.First(f => f.Key == "email");

            // Assert - Parent-Child relationship
            Assert.Equal(fieldGroup.Id, emailField.ParentId);
            Assert.Same(fieldGroup, emailField.FormlyFieldConfigParent);

            // Assert - Field to Props relationship
            Assert.NotNull(emailField.Props);
            Assert.Equal(emailField.Id, emailField.Props.FormlyFieldConfigId);
            Assert.Same(emailField, emailField.Props.FormlyFieldConfig);

            // Assert - Field to Validation relationship
            Assert.NotNull(emailField.Validation);
            Assert.Equal(emailField.Id, emailField.Validation.FormlyFieldConfigId);
            Assert.Same(emailField, emailField.Validation.FormlyFieldConfig);
            Assert.Equal(2, emailField.Validation.Messages.Count);
        }

        [Fact]
        public void BuildDynamicForm_PasswordField_ShouldHaveCorrectRelationships()
        {
            // Act
            var form = SeedFormData.BuildDynamicForm();
            var fieldGroup = form.Fields.First(f => !string.IsNullOrEmpty(f.FieldGroupClassName));
            var passwordField = fieldGroup.FieldGroup.First(f => f.Key == "password");

            // Assert - Field to Validation relationship
            Assert.NotNull(passwordField.Validation);
            Assert.Equal(passwordField.Id, passwordField.Validation.FormlyFieldConfigId);
            Assert.Same(passwordField, passwordField.Validation.FormlyFieldConfig);
            Assert.Equal(3, passwordField.Validation.Messages.Count);
            Assert.True(passwordField.Validation.Messages.ContainsKey("minlength"));
            Assert.True(passwordField.Validation.Messages.ContainsKey("maxlength"));
        }

        [Fact]
        public void BuildDynamicForm_RoleField_ShouldHaveCorrectRelationships()
        {
            // Act
            var form = SeedFormData.BuildDynamicForm();
            var fieldGroup = form.Fields.First(f => !string.IsNullOrEmpty(f.FieldGroupClassName));
            var roleField = fieldGroup.FieldGroup.First(f => f.Key == "role");

            // Assert - Field to Props relationship
            Assert.NotNull(roleField.Props);
            Assert.Equal(roleField.Id, roleField.Props.FormlyFieldConfigId);
            Assert.Same(roleField, roleField.Props.FormlyFieldConfig);

            // Assert - Props to Options relationship
            Assert.Equal(3, roleField.Props.Options.Count);
            Assert.All(roleField.Props.Options, option =>
            {
                Assert.Equal(roleField.Props.Id, option.FormlyFieldPropId);
                Assert.Same(roleField.Props, option.FormlyFieldProp);
            });
        }

        [Fact]
        public void BuildDynamicForm_RoleOptions_ShouldHaveCorrectValues()
        {
            // Act
            var form = SeedFormData.BuildDynamicForm();
            var fieldGroup = form.Fields.First(f => !string.IsNullOrEmpty(f.FieldGroupClassName));
            var roleField = fieldGroup.FieldGroup.First(f => f.Key == "role");
            var options = roleField.Props?.Options.ToList();

            // Assert
            Assert.NotNull(options);
            Assert.Contains(options, o => o.Value == "admin" && o.Label == "Administrator");
            Assert.Contains(options, o => o.Value == "user" && o.Label == "User");
            Assert.Contains(options, o => o.Value == "guest" && o.Label == "Guest");
        }

        [Fact]
        public void BuildDynamicForm_AllFieldsInGroup_ShouldHaveParentReference()
        {
            // Act
            var form = SeedFormData.BuildDynamicForm();
            var fieldGroup = form.Fields.First(f => !string.IsNullOrEmpty(f.FieldGroupClassName));

            // Assert
            Assert.All(fieldGroup.FieldGroup, field =>
            {
                Assert.Equal(fieldGroup.Id, field.ParentId);
                Assert.Same(fieldGroup, field.FormlyFieldConfigParent);
            });
        }

        [Fact]
        public void BuildDynamicForm_Navigation_FromOptionToFormShouldWork()
        {
            // Act
            var form = SeedFormData.BuildDynamicForm();
            var fieldGroup = form.Fields.First(f => !string.IsNullOrEmpty(f.FieldGroupClassName));
            var roleField = fieldGroup.FieldGroup.First(f => f.Key == "role");
            
            Assert.NotNull(roleField.Props);
            var adminOption = roleField.Props.Options.First(o => o.Value == "admin");

            // Act - Navigate from Option to Form
            var navigatedProps = adminOption.FormlyFieldProp;
            var navigatedField = navigatedProps.FormlyFieldConfig;
            var navigatedParent = navigatedField.FormlyFieldConfigParent;
            var navigatedForm = navigatedField.FormlyForm;

            // Assert
            Assert.Same(roleField.Props, navigatedProps);
            Assert.Same(roleField, navigatedField);
            Assert.Same(fieldGroup, navigatedParent);
            Assert.Same(form, navigatedForm);
            Assert.Equal("User", navigatedForm.Name);
        }
    }
}
